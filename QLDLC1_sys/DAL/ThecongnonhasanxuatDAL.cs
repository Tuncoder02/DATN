using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThecongnonhasanxuatDAL
    {

        private static ThecongnonhasanxuatDAL instance;
        public static ThecongnonhasanxuatDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThecongnonhasanxuatDAL();
                return instance;
            }
        }
        public List<NhaSX> getNSX()
        {
            List<NhaSX> list = DataProvider.Ins.DB.NhaSX.ToList();
            return list;
        }

        public class DebtCard
        {
            public DateTime TransactionDate { get; set; }
            public int DocumentID { get; set; }
            public string DocumentType { get; set; }
            public double DebitAmount { get; set; }
            public double CreditAmount { get; set; }
        }

        public List<DebtCard> GetDebtCards(int id, DateTime startDate, DateTime endDate)
        {

            // Lấy tất cả các giao dịch phát sinh nợ và có
            var salesTransactions = (
                from sb in DataProvider.Ins.DB.BillImport
                where sb.NhaSXId == id && sb.BillImportDate >= startDate && sb.BillImportDate <= endDate
                select new DebtCard
                {
                    TransactionDate = sb.BillImportDate,
                    DocumentID = sb.BillImportId,
                    DocumentType = "Nhập",
                    DebitAmount = DataProvider.Ins.DB.BillImportDetails
                                    .Where(sbd => sbd.BillImportId == sb.BillImportId)
                                    .Sum(sbd => (double)(sbd.product.ProductPrice * sbd.Quantity)) * (1 - sb.NhaSX.NhaSXChietkhau / 100) - sb.BillPay ?? 0,
                    CreditAmount = 0.0
                }
            );

            var receiptTransactions = (
                from r in DataProvider.Ins.DB.Payment
                where r.NhaSXId == id && r.PaymentDate >= startDate && r.PaymentDate <= endDate
                select new DebtCard
                {
                    TransactionDate = (DateTime)r.PaymentDate,
                    DocumentID = r.PaymentId,
                    DocumentType = "Chi",
                    DebitAmount = 0.0,
                    CreditAmount = r.TotalMoney ?? 0
                }
            );

            var transactions = salesTransactions.Union(receiptTransactions).OrderBy(t => t.TransactionDate).ToList();


            return transactions;
        }
        public double soDuDauKy(int id, DateTime startDate)
        {
            var openingDebit = (
                from sb in DataProvider.Ins.DB.BillImport
                where sb.NhaSXId == id && sb.BillImportDate < startDate
                select DataProvider.Ins.DB.BillImportDetails
                    .Where(sbd => sbd.BillImportId == sb.BillImportId)
                    .Sum(sbd => (double)(sbd.product.ProductPrice * sbd.Quantity)) * (1 - sb.NhaSX.NhaSXChietkhau / 100) - sb.BillPay
            ).DefaultIfEmpty(0.0).Sum();

            var openingCredit = (
                from r in DataProvider.Ins.DB.Payment
                where r.NhaSXId == id && r.PaymentDate < startDate
                select (double)r.TotalMoney
            ).DefaultIfEmpty(0.0).Sum();

            double openingBalance = (double)(openingDebit - openingCredit);
            return openingBalance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThecongnokhachhangDAL
    {

        private static ThecongnokhachhangDAL instance;
        public static ThecongnokhachhangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThecongnokhachhangDAL();
                return instance;
            }
        }
        public List<customer> getCustomers()
        {
            List<customer> list =  DataProvider.Ins.DB.customer.Where(x=>x.CustomerId>1).ToList();
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

        public List<DebtCard> GetDebtCards(int id,DateTime startDate,DateTime endDate)
        {
            
                // Lấy tất cả các giao dịch phát sinh nợ và có
                var salesTransactions = (
                    from sb in DataProvider.Ins.DB.BillExport
                    where sb.CustomerId == id && sb.BillExportDate >= startDate && sb.BillExportDate <= endDate
                    select new DebtCard
                    {
                        TransactionDate = sb.BillExportDate,
                        DocumentID = sb.BillExportId,
                        DocumentType = "Sales",
                        DebitAmount = DataProvider.Ins.DB.BillExportDetails
                                        .Where(sbd => sbd.BillExportId == sb.BillExportId)
                                        .Sum(sbd => (double)(sbd.product.ProductPrice * sbd.Quantity))*(1-sb.customer.dailycap1.chietkhau/100)-sb.BillPay??0,
                        CreditAmount = 0.0
                    }
                );

                var receiptTransactions = (
                    from r in DataProvider.Ins.DB.Receipts
                    where r.CustomerId == id && r.ReceiptsDate >= startDate && r.ReceiptsDate <= endDate
                    select new DebtCard
                    {
                        TransactionDate = (DateTime)r.ReceiptsDate,
                        DocumentID = r.ReceiptsId,
                        DocumentType = "Receipt",
                        DebitAmount = 0.0,
                        CreditAmount = r.TotalMoney??0
                    }
                );

                var transactions = salesTransactions.Union(receiptTransactions).OrderBy(t => t.TransactionDate).ToList();


                return transactions;
        }
        public double soDuDauKy(int id,DateTime startDate)
        {
            var openingDebit = (
                from sb in DataProvider.Ins.DB.BillExport
                where sb.CustomerId == id && sb.BillExportDate < startDate
                select DataProvider.Ins.DB.BillExportDetails
                    .Where(sbd => sbd.BillExportId == sb.BillExportId)
                    .Sum(sbd => (double)(sbd.product.ProductPrice * sbd.Quantity))*(1-sb.customer.dailycap1.chietkhau/100)-sb.BillPay
            ).DefaultIfEmpty(0.0).Sum();

            var openingCredit = (
                from r in DataProvider.Ins.DB.Receipts
                where r.CustomerId == id && r.ReceiptsDate < startDate
                select (double)r.TotalMoney
            ).DefaultIfEmpty(0.0).Sum();

           double openingBalance = (double)(openingDebit - openingCredit);
            return openingBalance;
        }
    }
}

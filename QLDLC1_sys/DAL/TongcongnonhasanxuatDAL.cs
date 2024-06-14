using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TongcongnonhasanxuatDAL
    {

        private static TongcongnonhasanxuatDAL instance;
        public static TongcongnonhasanxuatDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongcongnonhasanxuatDAL();
                return instance;
            }
        }

        public class DebtSummary
        {
            public string CustomerName { get; set; }
            public double OpeningBalance { get; set; }
            public double DebtAmount { get; set; }
            public double PaymentAmount { get; set; }


            public double ClosingBalance { get; set; }
        }

        public List<DebtSummary> GetDebtSummaries(DateTime startDate, DateTime endDate)
        {
            var report = DataProvider.Ins.DB.NhaSX
              .Select(c => new DebtSummary
              {
                  CustomerName = c.NhaSXName,
                  OpeningBalance = (c.BillImport
                      .Where(b => b.BillImportDate < startDate)
                      .SelectMany(b => b.BillImportDetails)
                      .Sum(d => d.Quantity * d.product.ProductPrice * (1 - c.NhaSXChietkhau / 100.0)) ?? 0.0) -
                      (c.BillImport.Where(y => y.BillImportDate < startDate).Sum(d => d.BillPay) ?? 0.0) -
                      (c.Payment
                      .Where(r => r.PaymentDate < startDate)
                      .Sum(r => r.TotalMoney) ?? 0.0),
                  DebtAmount = (c.BillImport
                      .Where(b => b.BillImportDate >= startDate && b.BillImportDate <= endDate)
                      .SelectMany(b => b.BillImportDetails)
                      .Sum(d => d.Quantity * d.product.ProductPrice * (1 - c.NhaSXChietkhau / 100.0)) ?? 0.0)
                       - (c.BillImport.Where(y => y.BillImportDate >= startDate && y.BillImportDate <= endDate).Sum(x => x.BillPay) ?? 0.0),

                  PaymentAmount = (c.Payment
                      .Where(r => r.PaymentDate >= startDate && r.PaymentDate <= endDate)
                      .Sum(r => r.TotalMoney) ?? 0.0)
              })
              .ToList();

            report.ForEach(r => r.ClosingBalance = r.OpeningBalance + r.DebtAmount - r.PaymentAmount);


            return report.ToList();
        }
    }
}

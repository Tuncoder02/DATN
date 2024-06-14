using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TongcongnokhachhangDAL
    {

        private static TongcongnokhachhangDAL instance;
        public static TongcongnokhachhangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongcongnokhachhangDAL();
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

        public List<DebtSummary> GetDebtSummaries(DateTime startDate,DateTime endDate)
        {
            var report = DataProvider.Ins.DB.customer.Where(dl=>dl.CustomerId>1)
              .Select(c => new DebtSummary
              {
                  CustomerName = c.CustomerFullName,
                  OpeningBalance = (c.BillExport
                      .Where(b => b.BillExportDate < startDate)
                      .SelectMany(b => b.BillExportDetails)
                      .Sum(d => d.Quantity * d.product.ProductPrice * (1 - c.dailycap1.chietkhau / 100.0)) ?? 0.0) - 
                      (c.BillExport.Where(y => y.BillExportDate < startDate).Sum(d=>d.BillPay) ?? 0.0) -
                      (c.Receipts
                      .Where(r => r.ReceiptsDate < startDate)
                      .Sum(r => r.TotalMoney) ?? 0.0) ,
                  DebtAmount = (c.BillExport
                      .Where(b => b.BillExportDate >= startDate && b.BillExportDate <= endDate)
                      .SelectMany(b => b.BillExportDetails)
                      .Sum(d => d.Quantity * d.product.ProductPrice * (1 - c.dailycap1.chietkhau / 100.0) )?? 0.0)
                       - (c.BillExport.Where(y => y.BillExportDate >= startDate && y.BillExportDate <= endDate).Sum(x => x.BillPay) ?? 0.0),
                      
                  PaymentAmount = (c.Receipts
                      .Where(r => r.ReceiptsDate >= startDate && r.ReceiptsDate <= endDate)
                      .Sum(r => r.TotalMoney) ?? 0.0)
              })
              .ToList();

            report.ForEach(r => r.ClosingBalance = r.OpeningBalance + r.DebtAmount - r.PaymentAmount);


            return report.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaocaotungsanphamDAL
    {
        private static BaocaotungsanphamDAL instance;
        public static BaocaotungsanphamDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaocaotungsanphamDAL();
                return instance;
            }
        }
        public class Transaction
        {
            public DateTime Date { get; set; }
            public int DocumentNumber { get; set; }
            public string Type { get; set; }
            public int Nhap { get; set; }
            public int Xuat { get; set; }


        }
        public List<Transaction> TransactionList(int productId,DateTime startDate,DateTime endDate)
        {
            List<Transaction> transactions = new List<Transaction>();

            var importQuery = from import in DataProvider.Ins.DB.BillImportDetails
                              where import.ProductId == productId && import.BillImport.BillImportDate >= startDate && import.BillImport.BillImportDate <= endDate
                              select new Transaction
                              {
                                  Date = import.BillImport.BillImportDate,
                                  DocumentNumber = import.BillImport.BillImportId,
                                  Nhap = import.Quantity??0,
                                  Xuat=0,
                                  Type = "Nhập"
                              };

            var exportQuery = from export in DataProvider.Ins.DB.BillExportDetails
                              where export.ProductId == productId && export.BillExport.BillExportDate >= startDate && export.BillExport.BillExportDate <= endDate
                              select new Transaction
                              {
                                  Date = export.BillExport.BillExportDate,
                                  DocumentNumber = export.BillExport.BillExportId,
                                  Nhap=0,
                                  Xuat = export.Quantity??0,
                                  Type = "Xuất"
                              };
            transactions.AddRange(importQuery);
            transactions.AddRange(exportQuery);

            transactions = transactions.OrderBy(t => t.Date)
                                       .ThenBy(t => t.DocumentNumber)
                                       .ToList();
            return transactions;
        }
        public int getSodudauky(int productId, DateTime startDate, DateTime endDate)
        {
            int startNhap = DataProvider.Ins.DB.BillImportDetails.Where(i => i.ProductId == productId && i.BillImport.BillImportDate < startDate)
                                      .Sum(i => i.Quantity) ?? 0; 
            int startXuat = DataProvider.Ins.DB.BillExportDetails.Where(e => e.ProductId == productId && e.BillExport.BillExportDate < startDate)
                                      .Sum(e => e.Quantity) ?? 0;
            return startNhap-startXuat;
        } 
    }

    
}

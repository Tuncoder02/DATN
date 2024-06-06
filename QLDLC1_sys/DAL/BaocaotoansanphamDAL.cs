using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaocaotoansanphamDAL
    {
        private static BaocaotoansanphamDAL instance;
        public static BaocaotoansanphamDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaocaotoansanphamDAL();
                return instance;
            }
        }
        public class ProductReport
        {
            public string ProductName { get; set; }
            public int StartingBalance { get; set; }
            public int IncomingQuantity { get; set; }
            public int OutgoingQuantity { get; set; }
            public int EndingBalance { get; set; }
        }
        public List<ProductReport> getDanhsach(DateTime startDate, DateTime endDate)
        {
            var report = from product in DataProvider.Ins.DB.product
                         let startingBalance = (DataProvider.Ins.DB.BillImportDetails.Where(x => x.ProductId == product.ProductId && x.BillImport.BillImportDate < startDate).Sum(x => x.Quantity) ?? 0)
                                               - (DataProvider.Ins.DB.BillExportDetails.Where(x => x.ProductId == product.ProductId && x.BillExport.BillExportDate < startDate).Sum(x => x.Quantity) ?? 0)
                         let incomingQuantity = DataProvider.Ins.DB.BillImportDetails.Where(x => x.ProductId == product.ProductId && x.BillImport.BillImportDate >= startDate && x.BillImport.BillImportDate <= endDate).Sum(x => x.Quantity)??0
                         let outgoingQuantity = DataProvider.Ins.DB.BillExportDetails.Where(x => x.ProductId == product.ProductId && x.BillExport.BillExportDate >= startDate && x.BillExport.BillExportDate <= endDate).Sum(x => x.Quantity)??0
                         let endingBalance = startingBalance + incomingQuantity - outgoingQuantity
                         select new ProductReport
                         {
                             ProductName = product.ProductName,
                             StartingBalance = startingBalance,
                             IncomingQuantity = (int)incomingQuantity,
                             OutgoingQuantity = (int)outgoingQuantity,
                             EndingBalance = (int)endingBalance
                         };
            return report.ToList();
        }


    }
}

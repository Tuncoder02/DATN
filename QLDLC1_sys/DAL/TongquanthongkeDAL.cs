using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TongquanthongkeDAL
    {
        private static TongquanthongkeDAL instance;
        public static TongquanthongkeDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongquanthongkeDAL();
                return instance;
            }
        }

        public class SanPhamNhapTrongKhoangThoiGian
        {
            public int SanPhamId { get; set; }
            public string TenSanPham { get; set; }

            public int TongSoLuong { get; set; }
        }

        public List<SanPhamNhapTrongKhoangThoiGian> getSPNhap(DateTime startDate,DateTime endDate)
        {
            var result = from b in DataProvider.Ins.DB.BillImport
                         join bd in DataProvider.Ins.DB.BillImportDetails on b.BillImportId equals bd.BillImportId
                         join p in DataProvider.Ins.DB.product on bd.ProductId equals p.ProductId
                         where b.BillImportDate >= startDate && b.BillImportDate <= endDate
                         group new { bd, p } by new { bd.ProductId, p.ProductName } into g
                         select new SanPhamNhapTrongKhoangThoiGian
                         {
                             SanPhamId = (int)g.Key.ProductId,
                             TenSanPham = g.Key.ProductName,
                             TongSoLuong = (int)g.Sum(x => x.bd.Quantity)
                         };
            return result.ToList();
        }

        public class SanPhamXuatTrongKhoangThoiGian
        {
            public int SanPhamId { get; set; }
            public string TenSanPham { get; set; }

            public int TongSoLuong { get; set; }
        }
        public List<SanPhamXuatTrongKhoangThoiGian> getSPXuat(DateTime startDate, DateTime endDate)
        {
            var result = from b in DataProvider.Ins.DB.BillExport
                         join bd in DataProvider.Ins.DB.BillExportDetails on b.BillExportId equals bd.BillExportId
                         join p in DataProvider.Ins.DB.product on bd.ProductId equals p.ProductId
                         where b.BillExportDate >= startDate && b.BillExportDate <= endDate
                         group new { bd, p } by new { bd.ProductId, p.ProductName } into g
                         select new SanPhamXuatTrongKhoangThoiGian
                         {
                             SanPhamId = (int)g.Key.ProductId,
                             TenSanPham = g.Key.ProductName,
                             TongSoLuong = (int)g.Sum(x => x.bd.Quantity)
                         };
            return result.ToList();
        }
        public class ProductInventory
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int? InventoryQuantity { get; set; }
        }
        public List<ProductInventory> getTon(DateTime endDate)
        {
            var inventory = from p in DataProvider.Ins.DB.product
                            join ni in DataProvider.Ins.DB.BillImportDetails on p.ProductId equals ni.ProductId into importDetails
                            from ni in importDetails.DefaultIfEmpty()
                            where ni != null && ni.BillImport.BillImportDate <= endDate
                            group new { ni.ProductId, ni.Quantity } by new { ni.ProductId, p.ProductName } into g
                            select new
                            {
                                g.Key.ProductId,
                                ProductName = g.Key.ProductName,
                                TotalImport = g.Sum(x => x.Quantity) ?? 0
                            };

            var sales = from p in DataProvider.Ins.DB.product
                        join ne in DataProvider.Ins.DB.BillExportDetails on p.ProductId equals ne.ProductId into exportDetails
                        from ne in exportDetails.DefaultIfEmpty()
                        where ne != null && ne.BillExport.BillExportDate <= endDate
                        group new { ne.ProductId, ne.Quantity } by new { ne.ProductId, p.ProductName } into g
                        select new
                        {
                            g.Key.ProductId,
                            ProductName = g.Key.ProductName,
                            TotalExport = g.Sum(x => x.Quantity) ?? 0
                        };

            var inventoryAtDate = from p in DataProvider.Ins.DB.product
                                  join inv in inventory on p.ProductId equals inv.ProductId into productInventory
                                  from inv in productInventory.DefaultIfEmpty()
                                  join sal in sales on p.ProductId equals sal.ProductId into productSales
                                  from sal in productSales.DefaultIfEmpty()
                                  select new ProductInventory
                                  {
                                      ProductId = p.ProductId,
                                      ProductName = p.ProductName,
                                      InventoryQuantity = (inv != null ? inv.TotalImport : 0) - (sal != null ? sal.TotalExport : 0)
                                  };
            return inventoryAtDate.ToList();
        }
        public class CustomerSalesSummary
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public int TotalProductsSold { get; set; }
        }
        public List<CustomerSalesSummary> getKhachhang(DateTime startDate,DateTime endDate)
        {
            var query = from bill in DataProvider.Ins.DB.BillExport
                        where bill.BillExportDate >= startDate && bill.BillExportDate <= endDate
                        join detail in DataProvider.Ins.DB.BillExportDetails on bill.BillExportId equals detail.BillExportId
                        join customer in DataProvider.Ins.DB.customer on bill.CustomerId equals customer.CustomerId
                        group detail by new { bill.CustomerId, customer.CustomerFullName } into g
                        select new CustomerSalesSummary
                        {
                            CustomerId = (int)g.Key.CustomerId,
                            CustomerName = g.Key.CustomerFullName,
                            TotalProductsSold = g.Sum(x => x.Quantity) ?? 0
                        };
            return query.ToList();
        }
        public class ProductTransactionSummary
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public double TotalPurchase { get; set; }
            public double TotalSales { get; set; }
        }
        public List<ProductTransactionSummary> getNhapxuat(DateTime startDate,DateTime endDate) 
        {
            // Truy vấn mua hàng
            var purchaseSummary = from purchase in DataProvider.Ins.DB.BillImportDetails
                                  where purchase.BillImport.BillImportDate >= startDate && purchase.BillImport.BillImportDate <= endDate
                                  group purchase by purchase.ProductId into purchaseGroup
                                  select new
                                  {
                                      ProductId = purchaseGroup.Key,
                                    
                                      TotalPurchase = purchaseGroup.Sum(p => p.Quantity * p.product.ProductPrice * (1 - p.BillImport.NhaSX.NhaSXChietkhau/100))??0
                                  };

            // Tính toán tổng tiền xuất cho mỗi sản phẩm trong khoảng thời gian
            var salesSummary = from sale in DataProvider.Ins.DB.BillExportDetails
                               where sale.BillExport.BillExportDate >= startDate && sale.BillExport.BillExportDate <= endDate
                               group sale by sale.ProductId into salesGroup
                               select new
                               {
                                   ProductId = salesGroup.Key,
                                   TotalSales = salesGroup.Sum(s => s.Quantity * s.product.ProductPrice * (1 - s.BillExport.customer.dailycap1.chietkhau/100))??0
                               };

            // Kết hợp kết quả từ tổng tiền nhập và tổng tiền xuất
            var productTransactionSummaries = from product in DataProvider.Ins.DB.product
                                              join purchase in purchaseSummary
                                              on product.ProductId equals purchase.ProductId into purchaseGroup
                                              from purchase in purchaseGroup.DefaultIfEmpty()
                                              join sale in salesSummary
                                              on product.ProductId equals sale.ProductId into salesGroup
                                              from sale in salesGroup.DefaultIfEmpty()
                                              select new ProductTransactionSummary
                                              {
                                                  ProductId = product.ProductId,
                                                  ProductName = product.ProductName,
                                                  TotalPurchase = purchase != null ? purchase.TotalPurchase : 0,
                                                  TotalSales = sale != null ? sale.TotalSales : 0
                                              };




            return productTransactionSummaries.ToList();

        }

    }
}

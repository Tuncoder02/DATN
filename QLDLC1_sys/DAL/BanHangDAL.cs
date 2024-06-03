using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BanHangDAL
    {

        private static BanHangDAL instance;
        public static BanHangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanHangDAL();
                return instance;
            }
        }

        public BillExport taoHoadon(int idcus)
        {
            BillExport bill = new BillExport();
            bill.BillExportDate = DateTime.Now;
            bill.BillDiscount = 0;
            bill.CustomerId = idcus;
            bill.BillPayPercent = 0;
            DataProvider.Ins.DB.BillExport.Add(bill);
            DataProvider.Ins.DB.SaveChanges();
            return bill;
        }
        public bool updateIdcus(int idbill,int idcus)
        {
            BillExport bill = DataProvider.Ins.DB.BillExport.Find(idbill);
            if (bill == null)
                return false;
            bill.CustomerId = idcus;
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool huyBill(int id)
        {
            BillExport bill = DataProvider.Ins.DB.BillExport.Find(id);
            if (bill == null)
                return false;
            DataProvider.Ins.DB.BillExport.Remove(bill);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
        public List<BillExportDetails> getBillInfo(int id)
        {
            List<BillExportDetails> result = DataProvider.Ins.DB.BillExportDetails.Where(x => x.BillExportId == id).ToList();
            return result;
        }

        public bool addBillInfo1(int idBill, int idProduct, int soluong)
        {
            BillExportDetails bill = new BillExportDetails();
            bill.BillExportId = idBill;
            bill.ProductId = idProduct;
            bill.Quantity = soluong;
            product pr = DataProvider.Ins.DB.product.Find(bill.ProductId);
            pr.ProductQuantity = pr.ProductQuantity - soluong;
            DataProvider.Ins.DB.BillExportDetails.Add(bill);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool addBillInfo2(int idBill, int soluong)
        {
            BillExportDetails bill = DataProvider.Ins.DB.BillExportDetails.Find(idBill);
            product pr=DataProvider.Ins.DB.product.Find(bill.ProductId);
            pr.ProductQuantity = pr.ProductQuantity - soluong;
            bill.Quantity = bill.Quantity + soluong;
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool deleteBill(int id)
        {
            BillExportDetails pr = DataProvider.Ins.DB.BillExportDetails.Find(id);
            if (pr != null)
            {
                product pr1 = DataProvider.Ins.DB.product.Find(pr.ProductId);
                pr1.ProductQuantity = pr.Quantity + pr1.ProductQuantity;
                DataProvider.Ins.DB.BillExportDetails.Remove(pr);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool updateProduct(int id, int soluong)
        {
            BillExportDetails pr = DataProvider.Ins.DB.BillExportDetails.Find(id);
            if (pr != null)
            {
                int am;
                am = soluong - (int)pr.Quantity;
                
                product pr1=DataProvider.Ins.DB.product.Find(pr.ProductId);
                if (pr1.ProductQuantity - am < 0) return false;
                pr1.ProductQuantity = pr1.ProductQuantity - am;
                pr.Quantity = soluong;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;

        }

        public bool luuBill(int idBill,int idKH,int pay)
        {
            int kt = 0;
            
  
            BillExport br= DataProvider.Ins.DB.BillExport.Find(idBill);
            br.CustomerId = idKH;
            br.BillPayPercent = pay;
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public List<BillExport> getBillExport()
        {
            List<BillExport> products = new List<BillExport>();
            products = DataProvider.Ins.DB.BillExport.ToList();
            return products;
        }

        public bool deleteBillTo(int id)
        {
            BillExport pr = DataProvider.Ins.DB.BillExport.Find(id);
            if (pr != null)
            {
                DataProvider.Ins.DB.BillExport.Remove(pr);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public class BillDetailWithDiscount
        {
            public int BillDetailId { get; set; }
            public int CustomerId { get; set; }
            public int BillId { get; set; }

            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public float Price { get; set; }
            public float DiscountAmount { get; set; }
            // Các trường khác từ BillDetail nếu cần
        }

        public List<BillDetailWithDiscount> GetBillDetailsWithDiscounts()
        {
            var result = from bd in DataProvider.Ins.DB.BillExportDetails
                         join b in DataProvider.Ins.DB.BillExport on bd.BillExportId equals b.BillExportId

                         join d in DataProvider.Ins.DB.chietkhausp on new { b.CustomerId, bd.ProductId } equals new { d.CustomerId, d.ProductId } into discountGroup
                         from dg in discountGroup.DefaultIfEmpty()
                         select new BillDetailWithDiscount
                         {
                             BillDetailId = bd.BillExportDetailsId,
                             BillId = (int)bd.BillExportId,
                             ProductId =(int) bd.ProductId,
                             ProductName=bd.product.ProductName,
                             Quantity =(int) bd.Quantity,
                             Price = (float)bd.product.ProductPrice,
                             DiscountAmount = dg == null ? 0 : (float)dg.chietkhau
                         };

            return result.ToList();
            
        }

    }
}

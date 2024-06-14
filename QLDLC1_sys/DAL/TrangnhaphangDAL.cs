using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TrangnhaphangDAL
    {

        private static TrangnhaphangDAL instance;
        public static TrangnhaphangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TrangnhaphangDAL();
                return instance;
            }
        }
        public BillImport taoHoadon(int nhasxid,DateTime date)
        {
            BillImport bill =new BillImport();
            bill.BillImportDate = date;
            bill.NhaSXId = nhasxid;
            DataProvider.Ins.DB.BillImport.Add(bill);
            DataProvider.Ins.DB.SaveChanges();
            return bill;
        }
        public bool huyBill(int id)
        {
           BillImport bill= DataProvider.Ins.DB.BillImport.Find(id);
            if (bill == null)
                return false;

            DataProvider.Ins.DB.BillImport.Remove(bill);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
        public List<BillImportDetails> getBillInfo(int id)
        {
            List<BillImportDetails> result = DataProvider.Ins.DB.BillImportDetails.Where(x=>x.BillImportId==id).ToList();
            return result;
        }

        public bool addBillInfo1(int idBill,int idProduct,int soluong)
        {
            BillImportDetails bill= new BillImportDetails();
            bill.BillImportId= idBill;
            bill.ProductId= idProduct;
            bill.Quantity= soluong;
         
            product pr = DataProvider.Ins.DB.product.Find(bill.ProductId);
            pr.ProductQuantity = pr.ProductQuantity + soluong;
            DataProvider.Ins.DB.BillImportDetails.Add(bill);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool addBillInfo2(int idBill, int soluong)
        {
            BillImportDetails bill = DataProvider.Ins.DB.BillImportDetails.Find(idBill);
            product pr=DataProvider.Ins.DB.product.Find(bill.ProductId);
            pr.ProductQuantity = pr.ProductQuantity + soluong;
            bill.Quantity = bill.Quantity + soluong;
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

         public bool deleteBill(int id)
        {
            BillImportDetails pr= DataProvider.Ins.DB.BillImportDetails.Find(id);
            if(pr != null)
            {

                product pr1 = DataProvider.Ins.DB.product.Find(pr.ProductId);
                if (pr1.ProductQuantity < pr.Quantity) return false;
                pr1.ProductQuantity = pr1.ProductQuantity - pr.Quantity;
                DataProvider.Ins.DB.BillImportDetails.Remove(pr);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool updateProduct(int id,int soluong)
        {
            BillImportDetails pr = DataProvider.Ins.DB.BillImportDetails.Find(id);
            if (pr != null)
            {
                int am;
                am = soluong - (int)pr.Quantity;
                product pr1 = DataProvider.Ins.DB.product.Find(pr.ProductId);
                if ((pr1.ProductQuantity + am) < 0) return false;
                pr.Quantity = soluong;
                pr1.ProductQuantity = pr1.ProductQuantity + am;
              
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;

        }

        public bool luuBill(int idBill,DateTime date,float thanhtoan)
        {
            
            BillImport bill=DataProvider.Ins.DB.BillImport.Find(idBill);
            if (bill == null)
                return false;
            bill.BillImportDate = date;
            bill.BillPay = thanhtoan;
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
    }
}

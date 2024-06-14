using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuthuDAL
    {

        private static PhieuthuDAL instance;
        public static PhieuthuDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuthuDAL();
                return instance;
            }
        }
        public List<Receipts> getReceipts()
        {
            List<Receipts> products = new List<Receipts>();
            products = DataProvider.Ins.DB.Receipts.ToList();
            return products;
        }
        public bool addReceipt(int customerid, float sotien,string noidung,DateTime ngaythu)
        {
            Receipts receipt = new Receipts();
            receipt.CustomerId = customerid;
            receipt.TotalMoney = sotien;
            receipt.Content= noidung;
            receipt.ReceiptsDate = ngaythu;
            DataProvider.Ins.DB.Receipts.Add(receipt);
            DataProvider.Ins.DB.SaveChanges();  
            return true;
        }
        public bool removeReceipt(int receiptid) 
        {
            Receipts receipt=DataProvider.Ins.DB.Receipts.Find(receiptid);
            if(receipt != null) 
            {
               DataProvider.Ins.DB.Receipts.Remove(receipt);
                DataProvider.Ins.DB.SaveChanges(); 
                return true;
            }
            return false;
        
        }
        public bool editReceipt(int receiptid,int customerid, float sotien, string noidung, DateTime ngaythu)
        {
            Receipts receipt = DataProvider.Ins.DB.Receipts.Find(receiptid);
            if(receipt != null) 
            {
            receipt.CustomerId = customerid;
            receipt.TotalMoney = sotien;
            receipt.Content = noidung;
            receipt.ReceiptsDate = ngaythu;
        
            DataProvider.Ins.DB.SaveChanges();
            return true;
            }
            return false;
        }
        public List<Receipts> getReceiptsBySDT(string sdt)
        {
            List<Receipts> products = new List<Receipts>();
            products = DataProvider.Ins.DB.Receipts.Where(x => x.customer.CustomerPhoneNumber == sdt).ToList();
            return products;
        }

    }
}

using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class PhieuthuBLL
    {
        private static PhieuthuBLL instance;
        public static PhieuthuBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuthuBLL();
                return instance;
            }
        }
        public void getReceipts(DataGridView data)
        {
            List<Receipts> result = PhieuthuDAL.Instance.getReceipts().ToList();
            var result2 = from c in result select new { Idphieuthu = c.ReceiptsId, Idcustomer = c.CustomerId, Tenkhachhang = c.customer.CustomerFullName, Sotien = c.TotalMoney, Noidung = c.Content, Ngaythu=c.ReceiptsDate };
            data.DataSource = result2.ToList();
        }
        public bool addReceipt(int customerid, float sotien, string noidung, DateTime ngaythu)
        {
            return PhieuthuDAL.Instance.addReceipt(customerid,sotien,noidung,ngaythu);
        }
        public bool removeReceipt(int receiptid)
        {
     
            return PhieuthuDAL.Instance.removeReceipt(receiptid);

        }
        public bool editReceipt(int receiptid, int customerid, float sotien, string noidung, DateTime ngaythu)
        {
          
            return PhieuthuDAL.Instance.editReceipt(receiptid,customerid,sotien,noidung,ngaythu);
        }
        public void getReceiptsBySDT(DataGridView data,string sdt)
        {
            List<Receipts> result = PhieuthuDAL.Instance.getReceiptsBySDT(sdt).ToList();
            var result2 = from c in result select new { Idphieuthu = c.ReceiptsId, Idcustomer = c.CustomerId, Tenkhachhang = c.customer.CustomerFullName, Sotien = c.TotalMoney, Noidung = c.Content, Ngaythu = c.ReceiptsDate };
            data.DataSource = result2.ToList();
        }
    }
}

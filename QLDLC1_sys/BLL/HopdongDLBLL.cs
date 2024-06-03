using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class HopdongDLBLL
    {
        private static HopdongDLBLL instance;
        public static HopdongDLBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HopdongDLBLL();
                return instance;
            }
        }
        public void loadDaily(ComboBox cb1, ComboBox cb2, ComboBox cb3)
        {
            List<customer> result = KhachHangDAL.Instance.GetDaily();
            cb1.DataSource = result;
            cb1.DisplayMember = "CustomerFullName";
            cb2.DataSource = result;
            cb2.DisplayMember = "CustomerPhoneNumber";
            cb3.DataSource = result;
            cb3.DisplayMember = "CustomerEmail";
        }
        public void loadChietkhau(DataGridView data, int id)
        {
            List<chietkhausp> result =HopdongDLDAL.Instance.GetDSChietkhau(id).ToList();
            var result2 = from c in result select new { Machietkhau=c.chietkhauid,Idsanpham=c.ProductId, Sanpham=c.product.ProductName,Chietkhau=c.chietkhau};
            data.DataSource = result2.ToList();
        }
        public bool addCk(int customerid, int product, float ck)
        {
            return HopdongDLDAL.Instance.addCk(customerid,product,ck);
        }

        public bool removeCk(int ckid)
        {
            
            return HopdongDLDAL.Instance.removeCk(ckid);

        }
        public bool editCk(int ckid, float ck)
        {
           
            return HopdongDLDAL.Instance.editCk(ckid,ck);
        }
        public bool checkAdd(int customerid, int productid)
        {
            
            return HopdongDLDAL.Instance.checkAdd(customerid,productid);
        }
    }
}

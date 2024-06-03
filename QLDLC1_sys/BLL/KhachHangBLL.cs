using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class KhachHangBLL
    {
        private static KhachHangBLL instance;
        public static KhachHangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBLL();
                return instance;
            }
        }
        public void loadKhachHang(DataGridView data)
        {
            List<customer> result = KhachHangDAL.Instance.GetCustomer();
            var result2 = from c in result select new {Id=c.CustomerId,Ten=c.CustomerFullName,SDT=c.CustomerPhoneNumber,Email=c.CustomerEmail,Diem=c.CustomerPoint,Tinh=c.provinces.full_name,Huyen=c.districts.full_name,Xa=c.wards1.full_name,isdaily=c.Isdailycap2,Ngaydangky=c.Ngaydk};
            //BindingList<product> bindingList = new BindingList<product>(result2);

            data.DataSource = result2.ToList();
        }

        public bool AddCustomer(string name, string sdt, string email, string codetinh, string codehuyen, string codexa, int isdaily)
        {
           
            return KhachHangDAL.Instance.AddCustomer(name,sdt,email,codetinh,codehuyen,codexa,isdaily);
        }
        public bool UpdateCustomer(int id, string name, string sdt, string email, string codetinh, string codehuyen, string codexa, int diem, DateTime date, int isdaily)
        {
          
            return KhachHangDAL.Instance.UpdateCustomer(id,name,sdt,email,codetinh,codehuyen,codexa,diem,date,isdaily);

        }
        public bool DeleteCustomer(int id)
        {
        
            return KhachHangDAL.Instance.DeleteCustomer(id);
        }

        public void searchKH(DataGridView dt,string sdt)
        {
            List<customer> customerList = KhachHangDAL.Instance.GetCustomer().Where(x=>x.CustomerPhoneNumber==sdt).ToList();
            var result2 = from c in customerList select new { Id = c.CustomerId, Ten = c.CustomerFullName, SDT = c.CustomerPhoneNumber, Email = c.CustomerEmail, Diem = c.CustomerPoint, Tinh = c.provinces.full_name, Huyen = c.districts.full_name, Xa = c.wards1.full_name, Ngaydangky = c.Ngaydk };

            dt.DataSource = result2.ToList();
        }
    }
}   

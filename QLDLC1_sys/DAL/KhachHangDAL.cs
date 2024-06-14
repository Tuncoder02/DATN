using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {

        private static KhachHangDAL instance;
        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAL();
                return instance;
            }
        }

        public List<customer> GetCustomer()
        {
            List<customer> products = new List<customer>();
            products = DataProvider.Ins.DB.customer.Where(x=>x.CustomerId>1).ToList();
            return products;
        }
        public List<customer> GetDaily()
        {
            List<customer> products = new List<customer>();
            products = DataProvider.Ins.DB.customer.Where(x => x.dailycap1!=null).ToList();
            return products;
        }
        public List<customer> GetCustomer1()
        {
            List<customer> products = new List<customer>();
            products = DataProvider.Ins.DB.customer.ToList();
            return products;
        }
        public bool AddCustomer(string name,string sdt,string email,string codetinh,string codehuyen,string codexa,int isdaily)
         { 
            customer ct= new customer();
            ct.CustomerFullName = name;
            ct.CustomerEmail = email;
            ct.CustomerPhoneNumber = sdt;
            ct.CustomerCity = codetinh;
            ct.CustomerDistrict = codehuyen;
            ct.CustomerWard=codexa;
            ct.Ngaydk=DateTime.Now;
            ct.Dailycap = isdaily;
            ct.CustomerPoint = 0;
            DataProvider.Ins.DB.customer.Add(ct);
            DataProvider.Ins.DB.SaveChanges();

            return true;
        }
        public bool UpdateCustomer(int id,string name,string sdt,string email, string codetinh, string codehuyen, string codexa,int diem,DateTime date,int isdaily)
        {
            customer ct = DataProvider.Ins.DB.customer.Find(id);
            ct.CustomerFullName = name;
            ct.CustomerPhoneNumber= sdt;
            ct.CustomerEmail= email;
            ct.CustomerCity= codetinh;
            ct.CustomerDistrict = codehuyen;
            ct.CustomerWard= codexa;
            ct.CustomerPoint= diem;
            ct.Ngaydk = date;
            ct.Dailycap = isdaily;
            DataProvider.Ins.DB.SaveChanges();
            return true;

        }
        public bool DeleteCustomer(int id)
        {
            customer ct = DataProvider.Ins.DB.customer.Find(id);

            DataProvider.Ins.DB.customer.Remove(ct);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

    }
}

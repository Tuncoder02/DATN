using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class ThuongdoanhsoBLL
    {
        private static ThuongdoanhsoBLL instance;
        public static ThuongdoanhsoBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThuongdoanhsoBLL();
                return instance;
            }
        }
        public void getBonus(DataGridView data)
        {
            List<Bonus> result = ThuongdoanhsoDAL.Instance.getBonus().ToList();
            var result2 = from c in result select new { Id = c.BonusId, Idcustomer = c.CustomerId, Tenkhachhang = c.customer.CustomerFullName, Sotien = c.TotalMoney, Noidung = c.Content, Ngaythu = c.BonusDate };
            data.DataSource = result2.ToList();
        }
        public bool addBonus(int customerid, float sotien, string noidung, DateTime ngaythu)
        {
            return ThuongdoanhsoDAL.Instance.addBonus(customerid, sotien, noidung, ngaythu);
        }
        public bool removeBonus(int id)
        {

            return ThuongdoanhsoDAL.Instance.removeBonus(id);

        }
        public bool editBonus(int id, int customerid, float sotien, string noidung, DateTime ngaythu)
        {

            return ThuongdoanhsoDAL.Instance.editBonus(id, customerid, sotien, noidung, ngaythu);
        }
        public void getBonusBySDT(DataGridView data, string sdt)
        {
            List<Bonus> result = ThuongdoanhsoDAL.Instance.getBonusBySDT(sdt).ToList();
            var result2 = from c in result select new { Id = c.BonusId, Idcustomer = c.CustomerId, Tenkhachhang = c.customer.CustomerFullName, Sotien = c.TotalMoney, Noidung = c.Content, Ngaythu = c.BonusDate };
            data.DataSource = result2.ToList();
        }


    }
}

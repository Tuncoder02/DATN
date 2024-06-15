using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThuongdoanhsoDAL
    {

        private static ThuongdoanhsoDAL instance;
        public static ThuongdoanhsoDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThuongdoanhsoDAL();
                return instance;
            }
        }
        public List<Bonus> getBonus()
        {
            List<Bonus> products = new List<Bonus>();
            products = DataProvider.Ins.DB.Bonus.ToList();
            return products;
        }
        public bool addBonus(int customerid, float sotien, string noidung, DateTime ngaythu)
        {
            Bonus receipt = new Bonus();
            receipt.CustomerId = customerid;
            receipt.TotalMoney = sotien;
            receipt.Content = noidung;
            receipt.BonusDate = ngaythu;
            DataProvider.Ins.DB.Bonus.Add(receipt);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
        public bool removeBonus(int id)
        {
            Bonus bn = DataProvider.Ins.DB.Bonus.Find(id);
            if (bn != null)
            {
                DataProvider.Ins.DB.Bonus.Remove(bn);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;

        }
        public bool editBonus(int id, int customerid, float sotien, string noidung, DateTime ngaythu)
        {
            Bonus bn = DataProvider.Ins.DB.Bonus.Find(id);
            if (bn != null)
            {
                bn.CustomerId = customerid;
                bn.TotalMoney = sotien;
                bn.Content = noidung;
                bn.BonusDate = ngaythu;

                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Bonus> getBonusBySDT(string sdt)
        {
            List<Bonus> products = new List<Bonus>();
            products = DataProvider.Ins.DB.Bonus.Where(x => x.customer.CustomerPhoneNumber == sdt).ToList();
            return products;
        }

    }
}

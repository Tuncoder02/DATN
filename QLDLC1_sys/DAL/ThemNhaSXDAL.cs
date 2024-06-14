using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThemNhaSXDAL
    {

        private static ThemNhaSXDAL instance;
        public static ThemNhaSXDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThemNhaSXDAL();
                return instance;
            }
        }
        public List<NhaSX> getNhaSX()
        {
            List<NhaSX> result=DataProvider.Ins.DB.NhaSX.ToList();
            return result;
        }
        public bool addNhaSX( string name, string sdt, string email, string xa, string huyen, string tinh, float chietkhau,DateTime date)
        {
            NhaSX nhasx = new NhaSX();
            nhasx.NhaSXName = name;
            nhasx.NhaSXSDT = sdt;
            nhasx.NhaSXEmail = email;
            nhasx.NhaSXWard = xa;
            nhasx.NhaSXDistrict = huyen;
            nhasx.NhaSXCity = tinh;
            nhasx.NhaSXChietkhau = chietkhau;
            nhasx.NhaSXDate=date;
            DataProvider.Ins.DB.NhaSX.Add(nhasx);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool DeleteNhaSX(int id)
        {
            NhaSX nhasx = DataProvider.Ins.DB.NhaSX.Find(id);
            if (nhasx == null)
                return false;
            List<product> products = DataProvider.Ins.DB.product.Where(c => c.NhaSXId == id).ToList();
            foreach (product p in products)
            {
                DataProvider.Ins.DB.product.Remove(p);
            }

            DataProvider.Ins.DB.NhaSX.Remove(nhasx);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
        public bool editNhaSX(int id,string name, string sdt, string email, string xa, string huyen, string tinh, float chietkhau,DateTime date)
        {
            NhaSX nhasx = DataProvider.Ins.DB.NhaSX.Find(id);
            nhasx.NhaSXName = name;
            nhasx.NhaSXSDT = sdt;
            nhasx.NhaSXEmail = email;
            nhasx.NhaSXWard = xa;
            nhasx.NhaSXDistrict = huyen;
            nhasx.NhaSXCity = tinh;

            nhasx.NhaSXChietkhau = chietkhau;
            nhasx.NhaSXDate= date;
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
    }
}

using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
   
        public class ThemnhaSXBLL
        {

            private static ThemnhaSXBLL instance;
            public static ThemnhaSXBLL Instance
            {
                get
                {
                    if (instance == null)
                        instance = new ThemnhaSXBLL();
                    return instance;
                }
            }
            public void getNhaSX(DataGridView data)
            {
            var result = ThemNhaSXDAL.Instance.getNhaSX();
            var result2 = from c in result select new { Id = c.NhaSXId, Ten = c.NhaSXName, SDT = c.NhaSXSDT, Email = c.NhaSXEmail,Tinh=c.provinces.full_name,Huyen=c.districts.full_name,Xa=c.wards.full_name, Chietkhau = c.NhaSXChietkhau, Date = c.NhaSXDate } ;

            data.DataSource= result2.ToList();

            }
            public bool addNhaSX(string name, string sdt, string email, string xa, string huyen, string tinh, float chietkhau,DateTime date)
            {

            return ThemNhaSXDAL.Instance.addNhaSX(name, sdt, email, xa, huyen, tinh, chietkhau,date); 
            }
        public void searchNhaSX(DataGridView data,string sdt)
        {
            var result = ThemNhaSXDAL.Instance.getNhaSX().Where(c=>c.NhaSXSDT==sdt);
            var result2 = from c in result select new { Id = c.NhaSXId, Ten = c.NhaSXName, SDT = c.NhaSXSDT, Email = c.NhaSXEmail, Tinh = c.provinces.full_name, Huyen = c.districts.full_name, Xa = c.wards.full_name, Chietkhau = c.NhaSXChietkhau, Date = c.NhaSXDate };
            data.DataSource = result2.ToList();


        }


        public bool DeleteNhaSX(int id)
            {
              
                return ThemNhaSXDAL.Instance.DeleteNhaSX(id);
            }
            public bool editNhaSX(int id, string name, string sdt, string email, string xa, string huyen, string tinh, float chietkhau,DateTime date)
            {
                return ThemNhaSXDAL.Instance.editNhaSX(id,name,sdt,email,xa,huyen,tinh,chietkhau,date);
            }
        public void cboNhaSX(ComboBox cb)
        {
            var result = ThemNhaSXDAL.Instance.getNhaSX();
            cb.DataSource= result.ToList();
        }
    }

        
        
        
 }



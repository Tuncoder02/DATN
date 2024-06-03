using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DangNhapBLL
    {


        public bool checkLogin(string TK, string MK)
        {
            List<Users> dsUsers = new List<Users>();
            DangNhapDAL dn = new DangNhapDAL();
            dsUsers = dn.getUsers();
            foreach (var i in dsUsers)
            {
                if (i.TaiKhoan == TK && i.MatKhau == MK)
                    return true;
            }
            return false;
        }
    }
}

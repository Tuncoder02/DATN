using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DangNhapDAL
    {
        public List<Users> getUsers()
        {
            List<Users> dsUsers = new List<Users>();
            dsUsers = DataProvider.Ins.DB.Users.ToList();
            return dsUsers;
        }

    }
}

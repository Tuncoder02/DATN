using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanphamBLL
    {
        private static SanphamBLL instance;
        public static SanphamBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanphamBLL();
                return instance;
            }
        }
        public bool addSanpham(int productgroup, string tensanpham, float gia, string mota,string img)
        {
            return SanphamDAL.Instance.addSanpham(productgroup, tensanpham, gia, mota,img);
        }
    }

}
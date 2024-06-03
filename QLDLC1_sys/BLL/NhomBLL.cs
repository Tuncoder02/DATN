using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhomBLL
    {
        private static NhomBLL instance;
        public static NhomBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomBLL();
                return instance;
            }
        }
        public bool addProductGroup(string ten)
        {
            return NhomSanPhamDAL.Instance.addProductgroup(ten);
        }
    }
    
}

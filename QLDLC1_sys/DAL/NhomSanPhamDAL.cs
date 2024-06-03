using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhomSanPhamDAL
    {

        private static NhomSanPhamDAL instance;
        public static NhomSanPhamDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomSanPhamDAL();
                return instance;
            }
        }

        public List<productgroup> GetProductGroup()
        {
            List<productgroup> productgroups = new List<productgroup>();
            productgroups = DataProvider.Ins.DB.productgroup.ToList();
            return productgroups;
        }

        public bool addProductgroup(string ten)
        {
            productgroup pg= new productgroup();    
            pg.ProductGroupName = ten;
            DataProvider.Ins.DB.productgroup.Add(pg);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
    }
}

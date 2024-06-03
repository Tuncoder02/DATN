using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanphamDAL
    {

        private static SanphamDAL instance;
        public static SanphamDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanphamDAL();
                return instance;
            }
        }
        public bool addSanpham(int productgroup, string tensanpham,float gia,string mota,string img)
        {
            product pr = new product();
            pr.ProductGroupName = productgroup;
            pr.ProductName= tensanpham;
            pr.ProductPrice = gia;
            pr.ProductInfo = mota;
            pr.ProductQuantity = 0;
            pr.ProductImageLink= img;
            DataProvider.Ins.DB.product.Add(pr);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

    }
}

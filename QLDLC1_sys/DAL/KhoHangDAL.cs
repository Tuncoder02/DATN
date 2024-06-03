using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhoHangDAL
    {

        private static KhoHangDAL instance;
        public static KhoHangDAL Instance
        {
            get
            {
                if(instance == null)
                    instance = new KhoHangDAL();
                return instance;
            }
        }

        public List<product> GetProducts()
        {
            List<product> products = new List<product>();
            products=DataProvider.Ins.DB.product.ToList();
            return products;
        }
        public bool deleteProduct(int id)
        {
            product pr= DataProvider.Ins.DB.product.Find(id);
            if(pr != null)
            {
               DataProvider.Ins.DB.product.Remove(pr);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool updateProduct(int id, string productname, float productprice, int productquantity, string productinfo,string img)
        {
            product pr = DataProvider.Ins.DB.product.Find(id);
            if (pr != null)
            {
                
                pr.ProductName= productname;
                pr.ProductPrice= productprice;
                pr.ProductQuantity= productquantity;
                pr.ProductInfo= productinfo;
                pr.ProductImageLink= img;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;

        }

    }
}

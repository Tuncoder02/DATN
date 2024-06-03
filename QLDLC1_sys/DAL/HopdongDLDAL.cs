using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HopdongDLDAL
    {

        private static HopdongDLDAL instance;
        public static HopdongDLDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HopdongDLDAL();
                return instance;
            }
        }

        public List<chietkhausp> GetDSChietkhau(int customerid)
        {
            List<chietkhausp> ck = new List<chietkhausp>();
            ck = DataProvider.Ins.DB.chietkhausp.Where(x => x.CustomerId==customerid).ToList();
            return ck;
        }

        public bool addCk(int customerid,int product,float ck) 
        {

            chietkhausp cksp=new chietkhausp();
            cksp.CustomerId = customerid;
            cksp.ProductId= product;
            cksp.chietkhau = ck;
            DataProvider.Ins.DB.chietkhausp.Add(cksp);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool removeCk(int ckid)
        {
            chietkhausp cksp = DataProvider.Ins.DB.chietkhausp.Find(ckid);
            if (cksp == null)
                return false;
            DataProvider.Ins.DB.chietkhausp.Remove(cksp);
            DataProvider.Ins.DB.SaveChanges();
            
            return true;

         }
        public bool editCk(int ckid,float ck)
        {
           chietkhausp cksp = DataProvider.Ins.DB.chietkhausp.Find(ckid);
            if (cksp == null)
                return false;
            cksp.chietkhau= ck;
            DataProvider.Ins.DB.SaveChanges();

            return true;
        }

        public bool checkAdd(int customerid,int productid)
        {
            chietkhausp cksp=DataProvider.Ins.DB.chietkhausp.Where(c => c.CustomerId == customerid && c.ProductId == productid)
            .FirstOrDefault();
            if (cksp == null) return true;
            return false;
        }
    }
}

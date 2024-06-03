using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LichsunhapDAL
    {

        private static LichsunhapDAL instance;
        public static LichsunhapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LichsunhapDAL();
                return instance;
            }
        }

        public List<BillImport> getBillImport()
        {
            List < BillImport > products = new List<BillImport>();
            products=DataProvider.Ins.DB.BillImport.ToList();
            return products;
        }
    }
}

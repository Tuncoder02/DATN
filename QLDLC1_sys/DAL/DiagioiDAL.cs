using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiagioiDAL
    {

        private static DiagioiDAL instance;
        public static DiagioiDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiagioiDAL();
                return instance;
            }
        }
        public List<provinces> GetProvinces()
        {
            List<provinces> products = new List<provinces>();
            products = DataProvider.Ins.DB.provinces.ToList();
            return products;
        }
        public List<districts> GetDistricts()
        {
            List<districts> products = new List<districts>();
            products = DataProvider.Ins.DB.districts.ToList();
            return products;
        }

        public List<wards> GetWards()
        {
            List<wards> products = new List<wards>();
            products = DataProvider.Ins.DB.wards.ToList();
            return products;
        }

        
    }
}

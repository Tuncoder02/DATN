using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KiemtradailyDAL
    {

        private static KiemtradailyDAL instance;
        public static KiemtradailyDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KiemtradailyDAL();
                return instance;
            }
        }

        public class DistrictCustomerCount
        {
            public string DistrictName { get; set; }
            public int AgentCount { get; set; }
            public int RegularCustomerCount { get; set; }
            public int TotalOrderDetailQuantity { get; set; }

        }
        public class WardCustomerCount
        {
            public string WardName { get; set; }
            public int AgentCount { get; set; }
            public int RegularCustomerCount { get; set; }
            public int TotalOrderDetailQuantity { get; set; }

        }

        public List<DistrictCustomerCount> GetCustomersCountByDistrict(string provinceId)
        {
          
               var customersByDistrict = DataProvider.Ins.DB.customer
                    .Where(c => c.CustomerCity == provinceId)
                    .GroupBy(c => c.districts)
                    .Select(g => new DistrictCustomerCount
                    {
                        DistrictName = g.Key.full_name,
                        AgentCount = g.Count(c => c.Dailycap!=null),
                        RegularCustomerCount = g.Count(c => c.Dailycap == null),
                        TotalOrderDetailQuantity = g.SelectMany(c => c.BillExport)
                                             .SelectMany(o => o.BillExportDetails)
                                             .Sum(od => (int?)od.Quantity) ?? 0
                    })
                    .ToList();
                return customersByDistrict;
            
        }
        public List<WardCustomerCount> GetCustomersCountByWard(string id)
        {

            var customersByDistrict = DataProvider.Ins.DB.customer
                .Where(c => c.CustomerDistrict == id)
                .GroupBy(c => c.wards)
                .Select(g => new WardCustomerCount
                {
                    WardName = g.Key.full_name,
                    AgentCount = g.Count(c => c.Dailycap != null),
                    RegularCustomerCount = g.Count(c => c.Dailycap == null),
                    TotalOrderDetailQuantity = g.SelectMany(c => c.BillExport)
                                         .SelectMany(o => o.BillExportDetails)
                                         .Sum(od => (int?)od.Quantity) ?? 0
                })
                .ToList();

            return customersByDistrict;

        }

    }
}

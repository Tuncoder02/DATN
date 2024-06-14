using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DailyDAL
    {
        private static DailyDAL instance;
        public static DailyDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DailyDAL();
                return instance;
            }
        }

        public void themloaidaily(string ten,float chietkhau)
        {
            dailycap dl=new dailycap();
            dl.dailyname = ten;
            dl.chietkhau = chietkhau;
            DataProvider.Ins.DB.dailycap.Add(dl);
            DataProvider.Ins.DB.SaveChanges();

        }
        public List<dailycap> getdailycap()
        {
            List<dailycap> result=DataProvider.Ins.DB.dailycap.ToList();
            return result;
        }
    }
}

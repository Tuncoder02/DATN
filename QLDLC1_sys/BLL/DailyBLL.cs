using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class DailyBLL
    {
        private static DailyBLL instance;
        public static DailyBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DailyBLL();
                return instance;
            }
        }

        public void themloaidaily(string ten, float chietkhau)
        {
           DailyDAL.Instance.themloaidaily(ten, chietkhau);

        }
        public void getdailycap(ComboBox cb)
        {
            var result = DailyDAL.Instance.getdailycap().ToList();
            cb.DataSource = result;
        }
    }
}

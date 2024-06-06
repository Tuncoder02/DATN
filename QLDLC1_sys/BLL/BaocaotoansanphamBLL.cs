using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class BaocaotoansanphamBLL
    {
        private static BaocaotoansanphamBLL instance;
        public static BaocaotoansanphamBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaocaotoansanphamBLL();
                return instance;
            }
        }
        public void loadDanhsach(DataGridView data,DateTime startDate,DateTime endDate)
        {
            var result=BaocaotoansanphamDAL.Instance.getDanhsach(startDate, endDate);
            data.DataSource = result;
        }
       
    }
}

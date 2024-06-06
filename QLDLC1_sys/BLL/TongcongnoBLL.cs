using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class TongcongnoBLL
    {
        private static TongcongnoBLL instance;
        public static TongcongnoBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongcongnoBLL();
                return instance;
            }
        }

        public void getCongNoReport(DataGridView data, DateTime tuNgay, DateTime denNgay)
        {
            var result = TongcongnoDAL.Instance.getCongNoReport(tuNgay, denNgay);
            if (result != null)
            {
               data.DataSource = result;
            }
        }
    }
}

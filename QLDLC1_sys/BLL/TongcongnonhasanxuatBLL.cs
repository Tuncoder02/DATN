using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class TongcongnonhasanxuatBLL
    {
        private static TongcongnonhasanxuatBLL instance;
        public static TongcongnonhasanxuatBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongcongnonhasanxuatBLL();
                return instance;
            }
        }

        public void getDanhSachCongNo(DataGridView data, DateTime startDate, DateTime endDate)
        {
            var result = TongcongnonhasanxuatDAL.Instance.GetDebtSummaries(startDate, endDate);
            data.DataSource = result;
        }
    }
}

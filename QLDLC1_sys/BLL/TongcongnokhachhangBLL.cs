using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class TongcongnokhachhangBLL
    {
        private static TongcongnokhachhangBLL instance;
        public static TongcongnokhachhangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongcongnokhachhangBLL();
                return instance;
            }
        }

        public void getDanhSachCongNo(DataGridView data, DateTime startDate,DateTime endDate)
        {
            var result=TongcongnokhachhangDAL.Instance.GetDebtSummaries(startDate, endDate);
            data.DataSource = result;
        }
    }
}

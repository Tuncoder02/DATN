using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class BaocaotungsanphamBLL
    {
        private static BaocaotungsanphamBLL instance;
        public static BaocaotungsanphamBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaocaotungsanphamBLL();
                return instance;
            }
        }

        public void loadChitiet(DataGridView data, int productid,DateTime startDate,DateTime endDate)
        {
            var result =BaocaotungsanphamDAL.Instance.TransactionList(productid, startDate, endDate);   
            data.DataSource= result;
        }
        public void getSodudauky(TextBox text, int productid, DateTime startDate, DateTime endDate)
        {
            int kq=BaocaotungsanphamDAL.Instance.getSodudauky(productid, startDate, endDate);   
            text.Text=kq.ToString();
        }

     }
}

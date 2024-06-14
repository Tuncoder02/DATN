using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class ThecongnokhachhangBLL
    {

        private static ThecongnokhachhangBLL instance;
        public static ThecongnokhachhangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThecongnokhachhangBLL();
                return instance;
            }
        }
        public void getDSKH(ComboBox cb)
        {
            List<customer> list = ThecongnokhachhangDAL.Instance.getCustomers();
            cb.DataSource= list;
        }
        public void getData(DataGridView data,int id,DateTime startDate,DateTime endDate)
        {
            var result = ThecongnokhachhangDAL.Instance.GetDebtCards(id,startDate,endDate);
            data.DataSource= result.ToList();
        }
        public double soDudauky(int id,DateTime startDate)
        {
            return ThecongnokhachhangDAL.Instance.soDuDauKy(id,startDate);
        }
    }
}

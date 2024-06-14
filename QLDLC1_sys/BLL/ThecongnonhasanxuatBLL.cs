using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class ThecongnonhasanxuatBLL
    {

        private static ThecongnonhasanxuatBLL instance;
        public static ThecongnonhasanxuatBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThecongnonhasanxuatBLL();
                return instance;
            }
        }
        public void getDSNSX(ComboBox cb)
        {
            List<NhaSX> list = ThecongnonhasanxuatDAL.Instance.getNSX();
            cb.DataSource = list;
        }
        public void getData(DataGridView data, int id, DateTime startDate, DateTime endDate)
        {
            var result = ThecongnonhasanxuatDAL.Instance.GetDebtCards(id, startDate, endDate);
            data.DataSource = result.ToList();
        }
        public double soDudauky(int id, DateTime startDate)
        {
            return ThecongnonhasanxuatDAL.Instance.soDuDauKy(id, startDate);
        }
    }
}

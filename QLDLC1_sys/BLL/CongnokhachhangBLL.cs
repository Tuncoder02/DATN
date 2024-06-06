using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class CongnokhachhangBLL
    {
        private static CongnokhachhangBLL instance;
        public static CongnokhachhangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CongnokhachhangBLL();
                return instance;
            }
        }

        public void getCongnokhachhang(DataGridView data, int id, DateTime tuNgay, DateTime denNgay)
        {
            var result = CongnokhachhangDAL.Instance.getCongnokhachhang(id, tuNgay, denNgay);
            if (result != null) 
            {
               data.DataSource = result;
            }
            
        }
        public void getSodudauky(TextBox text, int id, DateTime tuNgay, DateTime denNgay)
        {
            double result = CongnokhachhangDAL.Instance.sodudauky(id, tuNgay, denNgay);
            if (result != null)
            {
                text.Text = result.ToString();
            }


        }
        public void getCustomer(ComboBox cb1)
        {
            List<customer> result = KhachHangDAL.Instance.GetCustomer();
            //BindingList<product> bindingList = new BindingList<product>(result2);

            cb1.DataSource = result.ToList();
        }

    }
}

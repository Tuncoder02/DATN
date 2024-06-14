using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class LichsunhapBLL
    {
        private static LichsunhapBLL instance;
        public static LichsunhapBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LichsunhapBLL();
                return instance;
            }
        }

        public void  loadBillImport(DataGridView data)
        {
            List<BillImport> result = LichsunhapDAL.Instance.getBillImport();
            var result2 = from c in result select new { IdBill = c.BillImportId,Nhasx=c.NhaSX.NhaSXName,thanhtoan=c.BillPay, Ngaynhap = c.BillImportDate };
            //BindingList<product> bindingList = new BindingList<product>(result2);
            
            data.DataSource = result2.ToList();
        }
    }
}

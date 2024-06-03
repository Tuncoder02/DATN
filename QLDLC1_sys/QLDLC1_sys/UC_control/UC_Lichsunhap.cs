using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDLC1_sys.UC_control
{
    public partial class UC_Lichsunhap : UserControl
    {
        public UC_Lichsunhap()
        {
            InitializeComponent();
            LichsunhapBLL.Instance.loadBillImport(dtgvBillnhap);
            dtgvBillnhap.Columns[0].HeaderText = "Mã bill";
            dtgvBillnhap.Columns[1].HeaderText = "Thời gian";
            dtgvBillnhap.Columns[0].Width = 80;
            dtgvBillnhap.Columns[1].Width = 300;



        }

        private void UC_Lichsunhap_Load(object sender, EventArgs e)
        {

        }

        private void dtgvBillnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvBillnhap.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvBillnhap.Rows[e.RowIndex];
                    txtId.Text = row.Cells[0].Value.ToString();
                    dateThoigian.Value=(DateTime)row.Cells[1].Value;
                    int id=int.Parse(txtId.Text);
                    TrangnhaphangBLL.Instance.getBillInfo(dtgvChitietbill, id);
                    dtgvChitietbill.Columns[0].HeaderText = "Mã số";
                    dtgvChitietbill.Columns[1].HeaderText = "Mã SP";
                    dtgvChitietbill.Columns[2].HeaderText = "Tên sản phẩm";
                    dtgvChitietbill.Columns[3].HeaderText = "Số lượng";
                    dtgvChitietbill.Columns[4].HeaderText = "Giá nhập";
                    dtgvChitietbill.Columns[5].HeaderText = "Thành tiền";



                    dtgvChitietbill.Columns[0].Width = 80;
                    dtgvChitietbill.Columns[1].Width = 80;
                    dtgvChitietbill.Columns[2].Width = 300;
                    dtgvChitietbill.Columns[3].Width = 80;
                    dtgvChitietbill.Columns[4].Width = 150;
                    dtgvChitietbill.Columns[5].Width = 150;

                }
            }
        }
    }
}

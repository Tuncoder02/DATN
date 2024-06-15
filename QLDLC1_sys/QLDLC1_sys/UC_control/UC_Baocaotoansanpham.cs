using BLL;
using DAL;
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
    public partial class UC_Baocaotoansanpham : UserControl
    {
        public UC_Baocaotoansanpham()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            DateTime endDate= new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            DateTime startDate = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
            dateTuNgay.Value = startDate;
            BaocaotoansanphamBLL.Instance.loadDanhsach(dtgvTongsanpham, startDate, endDate);
            dtgvTongsanpham.Columns[0].HeaderText = "Tên sản phẩm";
            dtgvTongsanpham.Columns[1].HeaderText = "Số dư đầu kỳ";
            dtgvTongsanpham.Columns[2].HeaderText = "Nhập trong kỳ";
            dtgvTongsanpham.Columns[3].HeaderText = "Xuất trong kỳ";
            dtgvTongsanpham.Columns[4].HeaderText = "Số dư cuối kỳ";

            dtgvTongsanpham.Columns[0].Width = 250;
            dtgvTongsanpham.Columns[1].Width = 250;
            dtgvTongsanpham.Columns[2].Width = 250;
            dtgvTongsanpham.Columns[3].Width = 250;
            dtgvTongsanpham.Columns[4].Width = 250;

            dtgvTongsanpham.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dtgvTongsanpham.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dtgvTongsanpham.DefaultCellStyle.Font = new Font("Arial", 16);
            dtgvTongsanpham.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgvTongsanpham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dtgvTongsanpham.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            Tongdu();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Tongdu()
        {
            float total = 0;

            foreach (DataGridViewRow row in dtgvTongsanpham.Rows)
            {
                if (row.Cells["EndingBalance"].Value != null && float.TryParse(row.Cells["EndingBalance"].Value.ToString(), out float value))
                {
                    total += value;
                }
            }
            txtTongno.Text = total.ToString("F0");
        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, dateTuNgay.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dateDenNgay.Value.Year, dateDenNgay.Value.Month, dateDenNgay.Value.Day, 23, 59, 59);

            BaocaotoansanphamBLL.Instance.loadDanhsach(dtgvTongsanpham, startDate, endDate);
            dtgvTongsanpham.Columns[0].HeaderText = "Tên sản phẩm";
            dtgvTongsanpham.Columns[1].HeaderText = "Số dư đầu kỳ";
            dtgvTongsanpham.Columns[2].HeaderText = "Nhập trong kỳ";
            dtgvTongsanpham.Columns[3].HeaderText = "Xuất trong kỳ";
            dtgvTongsanpham.Columns[4].HeaderText = "Số dư cuối kỳ";

            dtgvTongsanpham.Columns[0].Width = 250;
            dtgvTongsanpham.Columns[1].Width = 250;
            dtgvTongsanpham.Columns[2].Width = 250;
            dtgvTongsanpham.Columns[3].Width = 250;
            dtgvTongsanpham.Columns[4].Width = 250;

            dtgvTongsanpham.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dtgvTongsanpham.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dtgvTongsanpham.DefaultCellStyle.Font = new Font("Arial", 16);
            dtgvTongsanpham.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgvTongsanpham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dtgvTongsanpham.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            Tongdu();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

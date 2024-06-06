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
    public partial class UC_Baocaotungsanpham : UserControl
    {
        public UC_Baocaotungsanpham()
        {
            InitializeComponent();
            TrangnhaphangBLL.Instance.loadIdSanPham(cbId);
            cbTen.DataSource = cbId.DataSource;
            cbId.DisplayMember = "ProductId";
            cbTen.DisplayMember = "ProductName";
        }

        private void UC_Baocaotungsanpham_Load(object sender, EventArgs e)
        {

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, dateTuNgay.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dateDenNgay.Value.Year, dateDenNgay.Value.Month, dateDenNgay.Value.Day, 23, 59, 59);
            int productid=int.Parse(cbId.Text);
            BaocaotungsanphamBLL.Instance.getSodudauky(txtSodudauky,productid,startDate,endDate);
            BaocaotungsanphamBLL.Instance.loadChitiet(dtgvChitietsanpham, productid, startDate, endDate);
            dtgvChitietsanpham.Columns[0].HeaderText = "Ngày phát sinh";
            dtgvChitietsanpham.Columns[1].HeaderText = "Số chứng từ";
            dtgvChitietsanpham.Columns[2].HeaderText = "Loại chứng từ";
            dtgvChitietsanpham.Columns[3].HeaderText = "Số nhập";
            dtgvChitietsanpham.Columns[4].HeaderText = "Số xuất";


            dtgvChitietsanpham.Columns[0].Width = 150;
            dtgvChitietsanpham.Columns[1].Width = 150;
            dtgvChitietsanpham.Columns[2].Width = 80;
            dtgvChitietsanpham.Columns[3].Width = 200;
            dtgvChitietsanpham.Columns[4].Width = 200;


            dtgvChitietsanpham.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dtgvChitietsanpham.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Cài đặt font chữ và kích thước cho các ô dữ liệu
            dtgvChitietsanpham.DefaultCellStyle.Font = new Font("Arial", 12);
            // Cài đặt kích thước cho các ô dữ liệu
            dtgvChitietsanpham.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgvChitietsanpham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Cài đặt font chữ và kích thước cho header
            dtgvChitietsanpham.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            Tongcuoiky();


        }
        private void Tongcuoiky()
        {
            double total1 = 0;
            double total2 = 0;
            foreach (DataGridViewRow row in dtgvChitietsanpham.Rows)
            {
                if (row.Cells["Nhap"].Value != null && double.TryParse(row.Cells["Nhap"].Value.ToString(), out double value))
                {
                    total1 += value;
                }
                if (row.Cells["Xuat"].Value != null && double.TryParse(row.Cells["Xuat"].Value.ToString(), out double value1))
                {
                    total2 += value1;
                }

            }
            double total = double.Parse(txtSodudauky.Text) + total1 - total2;
            txtSoducuoiky.Text = total.ToString("F0");
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

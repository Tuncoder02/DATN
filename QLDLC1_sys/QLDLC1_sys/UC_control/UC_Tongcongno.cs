using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDLC1_sys.UC_control
{
    public partial class UC_Tongcongno : UserControl
    {
        public UC_Tongcongno()
        {
            InitializeComponent();
            
            DateTime dt = DateTime.Now;
            DateTime startDate = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
            DateTime endDate = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            loadKhachhang(startDate,endDate);
            Tongno();

        }
        private void loadKhachhang(DateTime startDate,DateTime endDate)
        {
            
            dateTuNgay.Value = startDate;
            TongcongnokhachhangBLL.Instance.getDanhSachCongNo(dtgvTongcongno, startDate, endDate);
            dtgvTongcongno.Columns[0].HeaderText = "Tên khách hàng";
            dtgvTongcongno.Columns[1].HeaderText = "Số dư đầu kỳ";
            dtgvTongcongno.Columns[2].HeaderText = "Số tiền nợ trong kỳ";
            dtgvTongcongno.Columns[3].HeaderText = "Số thanh toán trong kỳ";
            dtgvTongcongno.Columns[4].HeaderText = "Số dư cuối kỳ";

            dtgvTongcongno.Columns[0].Width = 250;
            dtgvTongcongno.Columns[1].Width = 250;
            dtgvTongcongno.Columns[2].Width = 250;
            dtgvTongcongno.Columns[3].Width = 300;
            dtgvTongcongno.Columns[4].Width = 250;

            dtgvTongcongno.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dtgvTongcongno.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Cài đặt font chữ và kích thước cho các ô dữ liệu
            dtgvTongcongno.DefaultCellStyle.Font = new Font("Arial", 16);
            // Cài đặt kích thước cho các ô dữ liệu
            dtgvTongcongno.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgvTongcongno.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Cài đặt font chữ và kích thước cho header
            dtgvTongcongno.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
        }
        private void loadnhasanxuat(DateTime startDate, DateTime endDate)
        {

            dateTuNgay.Value = startDate;
            TongcongnonhasanxuatBLL.Instance.getDanhSachCongNo(dtgvTongcongno, startDate, endDate);
            dtgvTongcongno.Columns[0].HeaderText = "Tên nhà sản xuất";
            dtgvTongcongno.Columns[1].HeaderText = "Số dư đầu kỳ";
            dtgvTongcongno.Columns[2].HeaderText = "Số tiền nợ trong kỳ";
            dtgvTongcongno.Columns[3].HeaderText = "Số thanh toán trong kỳ";
            dtgvTongcongno.Columns[4].HeaderText = "Số dư cuối kỳ";

            dtgvTongcongno.Columns[0].Width = 250;
            dtgvTongcongno.Columns[1].Width = 250;
            dtgvTongcongno.Columns[2].Width = 250;
            dtgvTongcongno.Columns[3].Width = 300;
            dtgvTongcongno.Columns[4].Width = 250;

            dtgvTongcongno.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dtgvTongcongno.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Cài đặt font chữ và kích thước cho các ô dữ liệu
            dtgvTongcongno.DefaultCellStyle.Font = new Font("Arial", 16);
            // Cài đặt kích thước cho các ô dữ liệu
            dtgvTongcongno.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgvTongcongno.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Cài đặt font chữ và kích thước cho header
            dtgvTongcongno.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
        }
        private bool kiemtra = false;
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, dateTuNgay.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dateDenNgay.Value.Year, dateDenNgay.Value.Month, dateDenNgay.Value.Day, 23, 59, 59);
            if(kiemtra==false) loadKhachhang(startDate, endDate);
            else loadnhasanxuat(startDate, endDate);
            Tongno();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Tongno()
        {
            float total = 0;

            foreach (DataGridViewRow row in dtgvTongcongno.Rows)
            {
                if (row.Cells["ClosingBalance"].Value != null && float.TryParse(row.Cells["ClosingBalance"].Value.ToString(), out float value))
                {
                    total += value;
                }
            }
            txtTongno.Text = total.ToString("F0");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtgvTongcongno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTongno_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            kiemtra = !kiemtra;
            DateTime dt = DateTime.Now;
            DateTime startDate = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
            DateTime endDate = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);

            if (kiemtra == false)
            {
                lblTieude.Text = "CÔNG NỢ KHÁCH HÀNG";
                loadKhachhang(startDate, endDate);
            }
            else
            {
                lblTieude.Text = "CÔNG NỢ NHÀ SẢN XUẤT";
                loadnhasanxuat(startDate, endDate);
            }    

        }
    }
}

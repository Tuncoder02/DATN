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
    public partial class UC_Congnokhachhang : UserControl
    {
        public UC_Congnokhachhang()
        {
            InitializeComponent();
            CongnokhachhangBLL.Instance.getCustomer(cbMaKH);
           
            cbMaKH.DisplayMember = "CustomerId";
            cbEmail.DataSource=cbMaKH.DataSource;
            cbEmail.DisplayMember= "CustomerEmail";
            cbSodienthoai.DataSource=cbMaKH.DataSource;
            cbSodienthoai.DisplayMember = "CustomerPhoneNumber";
            cbTenkhachhang.DataSource=cbMaKH.DataSource;
            cbTenkhachhang.DisplayMember = "CustomerFullName";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            customer ct = cbMaKH.SelectedItem as customer;
            DateTime startDate = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, dateTuNgay.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dateDenNgay.Value.Year, dateDenNgay.Value.Month, dateDenNgay.Value.Day, 23, 59, 59);

            CongnokhachhangBLL.Instance.getCongnokhachhang(dtgvCongno, ct.CustomerId, startDate, endDate);
            CongnokhachhangBLL.Instance.getSodudauky(txtSodudauky, ct.CustomerId, startDate, endDate);
            dtgvCongno.Columns[0].HeaderText = "Ngày phát sinh";
            dtgvCongno.Columns[1].HeaderText = "Số chứng từ";
            dtgvCongno.Columns[2].HeaderText = "Phát sinh nợ";
            dtgvCongno.Columns[3].HeaderText = "Phát sinh có";

            dtgvCongno.Columns[0].Width = 150;
            dtgvCongno.Columns[1].Width = 150;
            dtgvCongno.Columns[2].Width = 200;
            dtgvCongno.Columns[3].Width = 200;

            dtgvCongno.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dtgvCongno.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Cài đặt font chữ và kích thước cho các ô dữ liệu
            dtgvCongno.DefaultCellStyle.Font = new Font("Arial", 12);
            // Cài đặt kích thước cho các ô dữ liệu
            dtgvCongno.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgvCongno.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Cài đặt font chữ và kích thước cho header
            dtgvCongno.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            Tongcuoiky();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbTenkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiachi.Text = null;
            customer ct = cbTenkhachhang.SelectedItem as customer;
            if (ct.CustomerId != 1)
                txtDiachi.Text = ct.wards1.full_name + ", " + ct.districts.full_name + ", " + ct.provinces.full_name;
        }
        private void Tongcuoiky()
        {
            double total1 = 0;
            double total2 = 0;
            foreach (DataGridViewRow row in dtgvCongno.Rows)
            {
                if (row.Cells["PhatSinhNo"].Value != null && double.TryParse(row.Cells["PhatSinhNo"].Value.ToString(), out double value))
                {
                    total1 += value;
                }
                if (row.Cells["PhatSinhCo"].Value != null && double.TryParse(row.Cells["PhatSinhCo"].Value.ToString(), out double value1))
                {
                    total2 += value1;
                }

            }
            double total = double.Parse(txtSodudauky.Text) + total1 - total2;
            txtSoducuoiky.Text = total.ToString("F0");
        }

        private void UC_Congnokhachhang_Load(object sender, EventArgs e)
        {

        }
    }
}

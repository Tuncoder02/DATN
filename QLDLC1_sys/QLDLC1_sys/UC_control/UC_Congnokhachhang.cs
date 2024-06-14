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
            loadkhachhang();
          
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            if (kiemtra == false) loadcongnokhachhang(); else loadcongnhasanxuat();
        
            
        }
        private bool kiemtra = false;
        private void loadkhachhang()
        {
            ThecongnokhachhangBLL.Instance.getDSKH(cbMaKH);
            cbMaKH.DisplayMember = "CustomerId";
            cbEmail.DataSource = cbMaKH.DataSource;
            cbEmail.DisplayMember = "CustomerEmail";
            cbSodienthoai.DataSource = cbMaKH.DataSource;
            cbSodienthoai.DisplayMember = "CustomerPhoneNumber";
            cbTenkhachhang.DataSource = cbMaKH.DataSource;
            cbTenkhachhang.DisplayMember = "CustomerFullName";
        }
        private void loadnhasanxuat()
        {
            ThecongnonhasanxuatBLL.Instance.getDSNSX(cbMaKH);
            cbMaKH.DisplayMember = "NhaSXId";
            cbEmail.DataSource = cbMaKH.DataSource;
            cbEmail.DisplayMember = "NhaSXEmail";
            cbSodienthoai.DataSource = cbMaKH.DataSource;
            cbSodienthoai.DisplayMember = "NhaSXSDT";
            cbTenkhachhang.DataSource = cbMaKH.DataSource;
            cbTenkhachhang.DisplayMember = "NhaSXName";
        }
        private void loadcongnokhachhang()
        {
            customer ct = cbMaKH.SelectedItem as customer;
            DateTime startDate = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, dateTuNgay.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dateDenNgay.Value.Year, dateDenNgay.Value.Month, dateDenNgay.Value.Day, 23, 59, 59);
            txtSodudauky.Text = ThecongnokhachhangBLL.Instance.soDudauky(ct.CustomerId, startDate).ToString();
            ThecongnokhachhangBLL.Instance.getData(dtgvCongno, ct.CustomerId, startDate, endDate);
            dtgvCongno.Columns[0].HeaderText = "Ngày phát sinh";
            dtgvCongno.Columns[1].HeaderText = "Số chứng từ";
            dtgvCongno.Columns[2].HeaderText = "Loại chứng từ";
            dtgvCongno.Columns[3].HeaderText = "Phát sinh nợ";
            dtgvCongno.Columns[4].HeaderText = "Phát sinh có";

            dtgvCongno.Columns[0].Width = 150;
            dtgvCongno.Columns[1].Width = 150;
            dtgvCongno.Columns[2].Width = 150;
            dtgvCongno.Columns[3].Width = 200;
            dtgvCongno.Columns[4].Width = 200;

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
        private void loadcongnhasanxuat()
        {
            NhaSX ct = cbMaKH.SelectedItem as NhaSX;
            DateTime startDate = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, dateTuNgay.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dateDenNgay.Value.Year, dateDenNgay.Value.Month, dateDenNgay.Value.Day, 23, 59, 59);
           txtSodudauky.Text = ThecongnonhasanxuatBLL.Instance.soDudauky(ct.NhaSXId, startDate).ToString();
            ThecongnonhasanxuatBLL.Instance.getData(dtgvCongno, ct.NhaSXId, startDate, endDate);
            dtgvCongno.Columns[0].HeaderText = "Ngày phát sinh";
            dtgvCongno.Columns[1].HeaderText = "Số chứng từ";
            dtgvCongno.Columns[2].HeaderText = "Loại chứng từ";
            dtgvCongno.Columns[3].HeaderText = "Phát sinh nợ";
            dtgvCongno.Columns[4].HeaderText = "Phát sinh có";

            dtgvCongno.Columns[0].Width = 150;
            dtgvCongno.Columns[1].Width = 150;
            dtgvCongno.Columns[2].Width = 150;
            dtgvCongno.Columns[3].Width = 200;
            dtgvCongno.Columns[4].Width = 200;

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
            if (kiemtra == false)
            {
                customer ct = cbTenkhachhang.SelectedItem as customer;

                if (ct.CustomerId != 1)
                    txtDiachi.Text = ct.wards.full_name + ", " + ct.districts.full_name + ", " + ct.provinces.full_name;
            }
            else
            {
                NhaSX ns = cbTenkhachhang.SelectedItem as NhaSX;
                txtDiachi.Text = ns.wards.full_name + ", " + ns.districts.full_name + ", " + ns.provinces.full_name;
            }
        }
        private void Tongcuoiky()
        {
            double total1 = 0;
            double total2 = 0;
            foreach (DataGridViewRow row in dtgvCongno.Rows)
            {
                if (row.Cells["DebitAmount"].Value != null && double.TryParse(row.Cells["DebitAmount"].Value.ToString(), out double value))
                {
                    total1 += value;
                }
                if (row.Cells["CreditAmount"].Value != null && double.TryParse(row.Cells["CreditAmount"].Value.ToString(), out double value1))
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

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            kiemtra = !kiemtra;
            if (kiemtra == false)
            {

                lblTieude.Text = "TRA CỨU\n CÔNG NỢ KHÁCH HÀNG";
                loadkhachhang();
                btnGuimail.Text = "Gửi mail cho khách hàng";
            }
            else
            {
                lblTieude.Text = "TRA CỨU\n CÔNG NỢ NHÀ SẢN XUẤT";
                loadnhasanxuat();
                btnGuimail.Text = "Gửi mail cho nhà SX";


            }
            dtgvCongno.DataSource = null;
        }

        private void txtDiachi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

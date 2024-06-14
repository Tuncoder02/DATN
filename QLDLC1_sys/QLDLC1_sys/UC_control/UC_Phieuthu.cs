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
    public partial class UC_Phieuthu : UserControl
    {
        public UC_Phieuthu()
        {
            InitializeComponent();

            loadkhachhang();
            loadPhieuthu();
            kiemtra();
            
        }
        public void loadPhieuthu()
        {
           PhieuthuBLL.Instance.getReceipts(dtgvPhieuthu);

            dtgvPhieuthu.Columns[0].HeaderText = "Mã phiếu";
            dtgvPhieuthu.Columns[1].HeaderText = "Mã KH/NSX";
            dtgvPhieuthu.Columns[2].HeaderText = "Tên KH/NSX ";
            dtgvPhieuthu.Columns[3].HeaderText = "Số tiền";
            dtgvPhieuthu.Columns[4].HeaderText = "Nội dung";
            dtgvPhieuthu.Columns[5].HeaderText = "Ngày thu/chi";


            dtgvPhieuthu.Columns[0].Width = 80;
            dtgvPhieuthu.Columns[1].Width = 80;
            dtgvPhieuthu.Columns[2].Width = 100;
            dtgvPhieuthu.Columns[3].Width = 100;
            dtgvPhieuthu.Columns[4].Width = 300;
            dtgvPhieuthu.Columns[5].Width = 100;
 

        }
        public void loadPhieuchi()
        {
            PhieuchiBLL.Instance.getPayment(dtgvPhieuthu);

            dtgvPhieuthu.Columns[0].HeaderText = "Mã phiếu";
            dtgvPhieuthu.Columns[1].HeaderText = "Mã KH/NSX";
            dtgvPhieuthu.Columns[2].HeaderText = "Tên KH/NSX ";
            dtgvPhieuthu.Columns[3].HeaderText = "Số tiền";
            dtgvPhieuthu.Columns[4].HeaderText = "Nội dung";
            dtgvPhieuthu.Columns[5].HeaderText = "Ngày thu/chi";


            dtgvPhieuthu.Columns[0].Width = 80;
            dtgvPhieuthu.Columns[1].Width = 80;
            dtgvPhieuthu.Columns[2].Width = 100;
            dtgvPhieuthu.Columns[3].Width = 100;
            dtgvPhieuthu.Columns[4].Width = 300;
            dtgvPhieuthu.Columns[5].Width = 100;


        }
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
        private void UC_Phieuthu_Load(object sender, EventArgs e)
        {

        }
        private bool kiemtrathuchi = false;
        private void cbTenkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiachi.Text = null;
            if (kiemtrathuchi == false)
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
        private bool kiemtraluu()
        {
            if (txtSotien.Text == "") return false;
            if (txtNoidung.Text == "") return false;
            return true;

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemtraluu() == true)
            {
                if (kiemtrathuchi == false)
                {
                    customer ct = cbTenkhachhang.SelectedItem as customer;
                    PhieuthuBLL.Instance.addReceipt(ct.CustomerId, float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
                    loadPhieuthu();
                }
                else
                {
                    NhaSX ns = cbTenkhachhang.SelectedItem as NhaSX;
                    PhieuchiBLL.Instance.addPayment(ns.NhaSXId, float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
                    loadPhieuchi();
                }
            }
            else MessageBox.Show("Số tiền và nội dung không được để trống");

        }

        private void dtgvPhieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvPhieuthu.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvPhieuthu.Rows[e.RowIndex];
                    txtMaphieu.Text = row.Cells[0].Value.ToString();
                    cbMaKH.Text = row.Cells[1].Value.ToString();
                    txtSotien.Text = row.Cells[3].Value.ToString();
            
                    txtNoidung.Text = row.Cells[4].Value.ToString();
                    dateNgayThu.Value =(DateTime) row.Cells[5].Value;

                }
            }
            kiemtra();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kiemtraluu() == true)
            {
                if (kiemtrathuchi == false)
                {

                    customer ct = cbTenkhachhang.SelectedItem as customer;
                    PhieuthuBLL.Instance.editReceipt(int.Parse(txtMaphieu.Text), ct.CustomerId, float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
                }
                else
                {
                    NhaSX ns = cbTenkhachhang.SelectedItem as NhaSX;
                    PhieuchiBLL.Instance.editPayment(int.Parse(txtMaphieu.Text), ns.NhaSXId, float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
                }
            btnLammoi_Click(sender, e);
            }
            else MessageBox.Show("Số tiền và nội dung không được để trống");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (kiemtrathuchi == false)
                PhieuthuBLL.Instance.removeReceipt(int.Parse(txtMaphieu.Text));
            else
                PhieuchiBLL.Instance.removePayment(int.Parse(txtMaphieu.Text));

            btnLammoi_Click(sender, e);

        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaphieu.Text = null;
            txtNoidung.Text=null;
            txtSotien.Text=null;
            txtSearch.Text=null;
            if (kiemtrathuchi == false) loadPhieuthu();
            else loadPhieuchi();
            kiemtra();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (kiemtrathuchi == false)
                PhieuthuBLL.Instance.getReceiptsBySDT(dtgvPhieuthu, txtSearch.Text);
            else PhieuchiBLL.Instance.getPaymentBySDT(dtgvPhieuthu, txtSearch.Text);
        }
        private void kiemtra()
        {
            if(txtMaphieu.Text=="")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }    
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            kiemtrathuchi = !kiemtrathuchi;
            if (kiemtrathuchi == false)
            {
                loadkhachhang();
                lblTieude.Text = "PHIẾU THU";
                btnLammoi_Click(sender, e);
             }
            else
            {
                loadnhasanxuat();
                lblTieude.Text = "PHIẾU CHI";
                btnLammoi_Click(sender, e);

            }
        }

        private void dtgvPhieuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}

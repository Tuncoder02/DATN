﻿using BLL;
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
            CongnokhachhangBLL.Instance.getCustomer(cbMaKH);

            cbMaKH.DisplayMember = "CustomerId";
            cbEmail.DataSource = cbMaKH.DataSource;
            cbEmail.DisplayMember = "CustomerEmail";
            cbSodienthoai.DataSource = cbMaKH.DataSource;
            cbSodienthoai.DisplayMember = "CustomerPhoneNumber";
            cbTenkhachhang.DataSource = cbMaKH.DataSource;
            cbTenkhachhang.DisplayMember = "CustomerFullName";
            loadPhieuthu();
            kiemtra();
            
        }
        public void loadPhieuthu()
        {
            PhieuthuBLL.Instance.getReceipts(dtgvPhieuthu);

            dtgvPhieuthu.Columns[0].HeaderText = "Mã phiếu";
            dtgvPhieuthu.Columns[1].HeaderText = "Mã KH";
            dtgvPhieuthu.Columns[2].HeaderText = "Tên khách hàng";
            dtgvPhieuthu.Columns[3].HeaderText = "Số tiền";
            dtgvPhieuthu.Columns[4].HeaderText = "Nội dung";
            dtgvPhieuthu.Columns[5].HeaderText = "Ngày thu";


            dtgvPhieuthu.Columns[0].Width = 80;
            dtgvPhieuthu.Columns[1].Width = 80;
            dtgvPhieuthu.Columns[2].Width = 100;
            dtgvPhieuthu.Columns[3].Width = 100;
            dtgvPhieuthu.Columns[4].Width = 300;
            dtgvPhieuthu.Columns[5].Width = 100;
 

        }
        private void UC_Phieuthu_Load(object sender, EventArgs e)
        {

        }

        private void cbTenkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiachi.Text = null;
            customer ct = cbTenkhachhang.SelectedItem as customer;
            if (ct.CustomerId != 1)
                txtDiachi.Text = ct.wards1.full_name + ", " + ct.districts.full_name + ", " + ct.provinces.full_name;
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
                customer ct = cbTenkhachhang.SelectedItem as customer;
                PhieuthuBLL.Instance.addReceipt(ct.CustomerId, float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
                loadPhieuthu();
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
                customer ct = cbTenkhachhang.SelectedItem as customer;
            PhieuthuBLL.Instance.editReceipt(int.Parse(txtMaphieu.Text),ct.CustomerId, float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
            btnLammoi_Click(sender, e);
            }
            else MessageBox.Show("Số tiền và nội dung không được để trống");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PhieuthuBLL.Instance.removeReceipt(int.Parse(txtMaphieu.Text));
            btnLammoi_Click(sender, e);

        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaphieu.Text = null;
            txtNoidung.Text=null;
            txtSotien.Text=null;
            txtSearch.Text=null;
            loadPhieuthu();
            kiemtra();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            PhieuthuBLL.Instance.getReceiptsBySDT(dtgvPhieuthu,txtSearch.Text);
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
        
    }
}
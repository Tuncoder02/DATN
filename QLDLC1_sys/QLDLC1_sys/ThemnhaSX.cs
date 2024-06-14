using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLDLC1_sys
{
    public partial class ThemnhaSX : Form
    {
        public ThemnhaSX()
        {
            InitializeComponent();
            ThemnhaSXBLL.Instance.getNhaSX(dtgvNhaSX);
            DiagioiBLL.Instance.loadProvinces(cboTinh);
            dtgvNhaSX.Columns[0].HeaderText = "Mã";
            dtgvNhaSX.Columns[1].HeaderText = "Tên";
            dtgvNhaSX.Columns[2].HeaderText = "SDT";
            dtgvNhaSX.Columns[3].HeaderText = "Email";
            dtgvNhaSX.Columns[4].HeaderText = "Tỉnh";
            dtgvNhaSX.Columns[5].HeaderText = "Huyện";
            dtgvNhaSX.Columns[6].HeaderText = "Xã";
            dtgvNhaSX.Columns[7].HeaderText = "Chiết khấu";
            dtgvNhaSX.Columns[8].HeaderText = "Ngày thêm";



            dtgvNhaSX.Columns[0].Width = 60;
            dtgvNhaSX.Columns[1].Width = 150;
            dtgvNhaSX.Columns[2].Width = 150;
            dtgvNhaSX.Columns[3].Width = 200;
            dtgvNhaSX.Columns[4].Width = 150;
            dtgvNhaSX.Columns[5].Width = 150;
            dtgvNhaSX.Columns[6].Width = 150;
            dtgvNhaSX.Columns[7].Width = 100;
            dtgvNhaSX.Columns[8].Width = 100;
            kiemtra();


        }

        private void ThemnhaSX_Load(object sender, EventArgs e)
        {

        }
        private void kiemtra()
        {
            if(txtMaNhaSX.Text=="")
            {
               btnCapnhat.Enabled = false;
               btnXoa.Enabled = false;
               btnThem.Enabled = true;
            }  
            else
            {
                btnCapnhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
         
            }
        }
        private bool kiemtrainput()
        {
            if (txtTenKH.Text == "") return false;
            if (txtSDT.Text == "") return false;
            if (txtEmail.Text == "") return false;
            if (txtChietkhau.Text == "") return false;
            if(cboXa.Text==null) return false;
            return true;
            
          }
        private void cboTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHuyen.Items.Clear();
            cboHuyen.Text = null;
            DiagioiBLL.Instance.loadDistricts(cboTinh, cboHuyen);
        }

        private void cboHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboXa.Items.Clear();
            cboXa.Text = null;
            DiagioiBLL.Instance.loadWards(cboHuyen, cboXa);
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaNhaSX.Text = null;
            txtEmail.Text = null;
            txtSDT.Text = null;
            txtTenKH.Text = null;
            cboTinh.SelectedItem = null;
            cboHuyen.SelectedItem = null;
            cboXa.SelectedItem = null;
            txtChietkhau.Text = null;
            dateNgaydangky.Value = DateTime.Now;
            txtSearch.Text = null;
            ThemnhaSXBLL.Instance.getNhaSX(dtgvNhaSX);
            kiemtra();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtrainput() == true)
            {
                provinces pr = cboTinh.SelectedItem as provinces;
                districts dt = cboHuyen.SelectedItem as districts;
                wards w = cboXa.SelectedItem as wards;
                bool result = ThemnhaSXBLL.Instance.addNhaSX(txtTenKH.Text, txtSDT.Text, txtEmail.Text, w.code, dt.code, pr.code, float.Parse(txtChietkhau.Text), dateNgaydangky.Value);
                btnLammoi_Click(sender, e);

            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (kiemtrainput() == true)
            {
                provinces pr = cboTinh.SelectedItem as provinces;
                districts dt = cboHuyen.SelectedItem as districts;
                wards w = cboXa.SelectedItem as wards;
                ThemnhaSXBLL.Instance.editNhaSX(int.Parse(txtMaNhaSX.Text), txtTenKH.Text, txtSDT.Text, txtEmail.Text, w.code, dt.code, pr.code, float.Parse(txtChietkhau.Text), dateNgaydangky.Value);
                btnLammoi_Click(sender, e);
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");


            }

       private void btnXoa_Click(object sender, EventArgs e)
        {
            ThemnhaSXBLL.Instance.DeleteNhaSX(int.Parse(txtMaNhaSX.Text));
            btnLammoi_Click(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemnhaSXBLL.Instance.searchNhaSX(dtgvNhaSX, txtSearch.Text);
        }

        private void dtgvNhaSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvNhaSX.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvNhaSX.Rows[e.RowIndex];
                    txtMaNhaSX.Text = row.Cells[0].Value.ToString();
                    txtTenKH.Text = row.Cells[1].Value.ToString();
                    txtSDT.Text = row.Cells[2].Value.ToString();
                    txtEmail.Text = row.Cells[3].Value.ToString();
                    cboTinh.Text = row.Cells[4].Value.ToString();
                    cboHuyen.Text = row.Cells[5].Value.ToString();
                    cboXa.Text = row.Cells[6].Value.ToString();
                    txtChietkhau.Text= row.Cells[7].Value.ToString();
                    dateNgaydangky.Value = (DateTime)row.Cells[8].Value;




                }
            }
            kiemtra();
        }
    } 
}

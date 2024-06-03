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
    public partial class UC_HopdongDL : UserControl
    {
        public UC_HopdongDL()
        {
            InitializeComponent();
            HopdongDLBLL.Instance.loadDaily(cbTenkhachhang, cbSodienthoai, cbEmail);
            TrangnhaphangBLL.Instance.loadIdSanPham(cbId);
            cbTen.DataSource = cbId.DataSource;
            cbId.DisplayMember = "ProductId";
            cbTen.DisplayMember = "ProductName";
            cbMaKH.DataSource = cbEmail.DataSource;
            cbMaKH.DisplayMember = "CustomerId";
            kiemtra();

        }

        private void UC_HopdongDL_Load(object sender, EventArgs e)
        {

        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtMachietkhau.Text = null;
            kiemtra();
        }
        private void loadChietkhau(int id)
        {
            HopdongDLBLL.Instance.loadChietkhau(dtgvChietkhau, id);
            dtgvChietkhau.Columns[0].HeaderText = "Mã CK";
            dtgvChietkhau.Columns[1].HeaderText = "Mã SP";
            dtgvChietkhau.Columns[2].HeaderText = "Tên sản phẩm";
            dtgvChietkhau.Columns[3].HeaderText = "Chiết khẩu";
            dtgvChietkhau.Columns[0].Width = 60;
            dtgvChietkhau.Columns[1].Width = 60;
            dtgvChietkhau.Columns[2].Width = 250;
            dtgvChietkhau.Columns[3].Width = 200;
        }
        private void kiemtra()
        {
            if(txtMachietkhau.Text=="")
            {
                btnSua.Enabled= false;
                btnXoa.Enabled= false;
            }    
            else
            {
                btnSua.Enabled= true;   
                btnXoa.Enabled= true;
            }
         
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtChietkhau.Text == "") MessageBox.Show("Tỉ lệ chiết khấu không được bỏ trống!");
            else
            {
                int productid = int.Parse(cbId.Text);
                int customerid = int.Parse(cbMaKH.Text);
                float ck = float.Parse(txtChietkhau.Text);
                bool kt = HopdongDLBLL.Instance.checkAdd(customerid, productid);
                if (kt)
                {
                    HopdongDLBLL.Instance.addCk(customerid, productid, ck);
                    loadChietkhau(customerid);
                    txtChietkhau.Text = null;
                }
                else MessageBox.Show("Hợp đồng với sản phẩm này đã tồn tại chỉ có thể sửa!");
            }
         }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbTenkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer ct = cbTenkhachhang.SelectedItem as customer;
            txtDiachi.Text = ct.wards1.full_name + ", " + ct.districts.full_name + ", " + ct.provinces.full_name;
            loadChietkhau(ct.CustomerId);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int mack = int.Parse(txtMachietkhau.Text);
            float ck= float.Parse(txtChietkhau.Text);
            HopdongDLBLL.Instance.editCk(mack, ck);
            int makh=int.Parse(cbMaKH.Text);
            loadChietkhau(makh);
            txtChietkhau.Text = null;
            txtMachietkhau.Text = null;
            kiemtra();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Bạn có chắc chắn muốn xóa?",
       "Warning",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int mack = int.Parse(txtMachietkhau.Text);
                HopdongDLBLL.Instance.removeCk(mack);
                int makh = int.Parse(cbMaKH.Text);
                loadChietkhau(makh);
                txtChietkhau.Text = null;
                txtMachietkhau.Text = null;
                kiemtra();
            }
        }

        private void dtgvChietkhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvChietkhau.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvChietkhau.Rows[e.RowIndex];
                    txtMachietkhau.Text = row.Cells[0].Value.ToString();
                    cbId.Text = row.Cells[1].Value.ToString();
                    txtChietkhau.Text = row.Cells[3].Value.ToString();


                }
            }
            kiemtra();
        }
    }
}

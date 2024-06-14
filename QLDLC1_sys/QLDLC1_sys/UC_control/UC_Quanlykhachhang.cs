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
    public partial class UC_Quanlykhachhang : UserControl
    {
        public UC_Quanlykhachhang()
        {
            InitializeComponent();
            DiagioiBLL.Instance.loadProvinces(cboTinh);
            KhachHangBLL.Instance.loadKhachHang(dtgvKhachhang);
            DailyBLL.Instance.getdailycap(cboDaily);
            cboDaily.DisplayMember = "dailyname";
            dtgvKhachhang.Columns[0].HeaderText = "Mã KH";
            dtgvKhachhang.Columns[1].HeaderText = "Tên khách hàng";
            dtgvKhachhang.Columns[2].HeaderText = "SĐT";
            dtgvKhachhang.Columns[3].HeaderText = "Email";
            dtgvKhachhang.Columns[4].HeaderText = "Tích điểm";
            dtgvKhachhang.Columns[5].HeaderText = "Tỉnh";
            dtgvKhachhang.Columns[6].HeaderText = "Huyện";
            dtgvKhachhang.Columns[7].HeaderText = "Xã";
            dtgvKhachhang.Columns[8].HeaderText = "Là đại lý";
            dtgvKhachhang.Columns[9].HeaderText = "Ngày đăng ký";

            dtgvKhachhang.Columns[0].Width = 60;
            dtgvKhachhang.Columns[1].Width = 150;
            dtgvKhachhang.Columns[2].Width = 150;
            dtgvKhachhang.Columns[3].Width = 150;
            dtgvKhachhang.Columns[4].Width = 100;
            dtgvKhachhang.Columns[5].Width = 100;
            dtgvKhachhang.Columns[6].Width = 100;
            dtgvKhachhang.Columns[7].Width = 100;
            dtgvKhachhang.Columns[8].Width = 100;
            dtgvKhachhang.Columns[9].Width = 100;

            kiemtra();


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

        private void UC_Quanlykhachhang_Load(object sender, EventArgs e)
        {

        }
        private void kiemtra()
        {
            if(txtMaKH.Text=="")
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
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = null;
            txtEmail.Text = null;
            txtSDT.Text = null;
            txtTenKH.Text = null;
            cboTinh.SelectedItem = null;
            cboHuyen.SelectedItem = null;
            cboXa.SelectedItem = null;  
            nbrDiem.Value = 0;
            dateNgaydangky.Value=DateTime.Now;
            txtSearch.Text = null;
            KhachHangBLL.Instance.loadKhachHang(dtgvKhachhang);

            kiemtra();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtraKH() == true)
            {
                provinces tinh = cboTinh.SelectedItem as provinces;
                districts huyen = cboHuyen.SelectedItem as districts;
                wards xa = cboXa.SelectedItem as wards;
                dailycap dl=cboDaily.SelectedItem as dailycap;
                KhachHangBLL.Instance.AddCustomer(txtTenKH.Text, txtSDT.Text, txtEmail.Text, tinh.code, huyen.code, xa.code,dl.dailyid) ;
                btnLammoi_Click(sender, e);
                KhachHangBLL.Instance.loadKhachHang(dtgvKhachhang);
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng!");

        }

        private void dtgvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvKhachhang.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvKhachhang.Rows[e.RowIndex];
                    txtMaKH.Text = row.Cells[0].Value.ToString();
                    txtTenKH.Text = row.Cells[1].Value.ToString();
                    txtSDT.Text = row.Cells[2].Value.ToString();
                    txtEmail.Text = row.Cells[3].Value.ToString();
                    cboTinh.Text = row.Cells[5].Value.ToString();
                    cboHuyen.Text = row.Cells[6].Value.ToString();
                    cboXa.Text = row.Cells[7].Value.ToString();
                    nbrDiem.Value = int.Parse(row.Cells[4].Value.ToString());

                   cboDaily.Text = row.Cells[8].Value.ToString();
                    
                    dateNgaydangky.Value= (DateTime)row.Cells[9].Value;

                }
            }
            kiemtra();

        }
        private bool kiemtraKH()
        {
            if (txtTenKH.Text == "") return false;
            if(txtSDT.Text =="") return false;
            if(txtEmail.Text=="") return false;
            if(cboXa.SelectedItem == null) return false;
            if (cboDaily.SelectedItem == null) return false;
            return true;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            provinces tinh = cboTinh.SelectedItem as provinces;
            districts huyen = cboHuyen.SelectedItem as districts;
            wards xa = cboXa.SelectedItem as wards;
            int id=int.Parse(txtMaKH.Text);
            DateTime date = dateNgaydangky.Value;
            int diem=(int)nbrDiem.Value;
            dailycap dl=cboDaily.SelectedItem as dailycap;
            KhachHangBLL.Instance.UpdateCustomer(id,txtTenKH.Text, txtSDT.Text, txtEmail.Text, tinh.code, huyen.code, xa.code,diem,date,dl.dailyid);
            btnLammoi_Click(sender, e);
            KhachHangBLL.Instance.loadKhachHang(dtgvKhachhang);
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
                int id = int.Parse(txtMaKH.Text);
                KhachHangDAL.Instance.DeleteCustomer(id);
                btnLammoi_Click(sender, e);
                KhachHangBLL.Instance.loadKhachHang(dtgvKhachhang);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhachHangBLL.Instance.searchKH(dtgvKhachhang,txtSearch.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kiemtradaily kt =new Kiemtradaily();
            kt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Daily dl=new Daily();
            dl.ShowDialog();
        }
    }
}

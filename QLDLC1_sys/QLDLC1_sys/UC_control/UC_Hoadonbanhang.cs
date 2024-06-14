using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDLC1_sys.UC_control
{
    public partial class UC_Hoadonbanhang : UserControl
    {
        private List<product> products;
        public UC_Hoadonbanhang()
        {
            InitializeComponent();
       

            BanHangBLL.Instance.loadCustomer(cbTenkhachhang, cbSodienthoai, cbEmail);
            TrangnhaphangBLL.Instance.loadIdSanPham(cbId);
            cbTen.DataSource = cbId.DataSource;
            cbId.DisplayMember = "ProductId";
            cbTen.DisplayMember = "ProductName";
            cbMaKH.DataSource=cbEmail.DataSource;
            cbMaKH.DisplayMember = "CustomerId";
            products = cbId.DataSource as List<product>;

            BanHangBLL.Instance.loadBillExport(dtgvBillban);
            dtgvBillban.Columns[0].HeaderText = "Mã bill";
            dtgvBillban.Columns[1].HeaderText = "Id khách hàng";
            dtgvBillban.Columns[2].HeaderText = "Thanh toán(%)";
            dtgvBillban.Columns[3].HeaderText = "Ngày";
            dtgvBillban.Columns[0].Width = 80;
            dtgvBillban.Columns[1].Width = 80;
            dtgvBillban.Columns[2].Width = 100;
            dtgvBillban.Columns[3].Width = 300;

          
            kiemtra();


        }
      
        public bool checkupdate = false;
        private void kiemtra()
        {
            if(txtId.Text=="")
            {
                btnThem.Enabled = false;
                btnXoahd.Enabled = false;
                btnLuu.Enabled = false;

            }    
            else
            {
                btnThem.Enabled = true;
                btnXoahd.Enabled = true;
                btnLuu.Enabled = true;
            }    
            if(txtMabillinfo.Text=="")
            {
                btnXoa.Enabled=false;
                btnSua.Enabled=false;
            }
            else
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
        }
        private void UC_Hoadonbanhang_Load(object sender, EventArgs e)
        {

        }

        private void cbTenkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiachi.Text = null;
            txtChietkhau.Text = null;
            customer ct = cbTenkhachhang.SelectedItem as customer;

            if (ct.CustomerId != 1)
            {
                txtDiachi.Text = ct.wards.full_name + ", " + ct.districts.full_name + ", " + ct.provinces.full_name;
                txtChietkhau.Text = ct.dailycap1.chietkhau.ToString();
                txtThanhtoan.ReadOnly = false;
            }
            else { txtThanhtoan.ReadOnly = true; }
         }

        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            product pr=cbTen.SelectedItem as product;
            txtGia.Text=pr.ProductPrice.ToString();
            if (checkupdate == true)
            {

                MessageBox.Show("Chỉ được thay đổi mục số lượng cho bill đã tồn tại!");
                txtMabillinfo.Text = null;
                checkupdate = false;
                nbrSoluong.Value = 0;

                kiemtra();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cbMaKH.Text = "1";
            int idcus = int.Parse(cbMaKH.Text);
            BillExport bill = BanHangBLL.Instance.taoHoaDon(idcus);
            txtId.Text = bill.BillExportId.ToString();
            dateNgayban.Value = bill.BillExportDate;
            int id = int.Parse(txtId.Text);

            BanHangBLL.Instance.getBillInfo(dtgvBillbaninfo, id);
           

            dtgvBillbaninfo.Columns[0].HeaderText = "Mã số";
            dtgvBillbaninfo.Columns[1].HeaderText = "Mã SP";
            dtgvBillbaninfo.Columns[2].HeaderText = "Tên sản phẩm";
            dtgvBillbaninfo.Columns[3].HeaderText = "Số lượng";
            dtgvBillbaninfo.Columns[4].HeaderText = "Giá bán";
            dtgvBillbaninfo.Columns[5].HeaderText = "Thành tiền";



            dtgvBillbaninfo.Columns[0].Width = 80;
            dtgvBillbaninfo.Columns[1].Width = 80;
            dtgvBillbaninfo.Columns[2].Width = 300;
            dtgvBillbaninfo.Columns[3].Width = 80;
            dtgvBillbaninfo.Columns[4].Width = 150;
      
            dtgvBillbaninfo.Columns[5].Width = 150;
            kiemtra();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            product pr = cbId.SelectedItem as product;
            int sl = (int)nbrSoluong.Value;
            if ((sl > 0)&&(sl<=pr.ProductQuantity))
            {
                int idBill = int.Parse(txtId.Text);
                int product = int.Parse(cbId.Text);
                int soluong = (int)nbrSoluong.Value;

                BanHangBLL.Instance.addBillInfo(idBill, product, soluong);

                BanHangBLL.Instance.getBillInfo(dtgvBillbaninfo, idBill);
                txtMabillinfo.Text = null;
                checkupdate = false;

                nbrSoluong.Value = 0;

                Tongtien();
            }
            else MessageBox.Show("Số sản phẩm còn lại trong kho là "+pr.ProductQuantity.ToString()+ "\nSố lượng phải lơn hơn 0 và bé hơn "+ pr.ProductQuantity.ToString() + "!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (txtThanhtoan.Text == "") txtThanhtoan.Text="0";
            int idKH = int.Parse(cbMaKH.Text);
            int pay =int.Parse(txtThanhtoan.Text);
            int idbill=int.Parse(txtId.Text);
            if(idKH==1) pay=int.Parse(txtTongtien.Text);
            BanHangBLL.Instance.luuBill(idbill, idKH, pay,dateNgayban.Value);
            BanHangBLL.Instance.loadBillExport(dtgvBillban);
            txtId.Text = null;
            dtgvBillbaninfo.DataSource = null; 
            txtTongtien.Text = null;
            txtMabillinfo.Text = null;
            checkupdate = false;
            cbMaKH.Text = "1";
            kiemtra();


        }

        private void dtgvBillbaninfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkupdate = false;

            Int32 selectedRowCount = dtgvBillbaninfo.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvBillbaninfo.Rows[e.RowIndex];
                    txtMabillinfo.Text = row.Cells[0].Value.ToString();
                    cbId.Text = row.Cells[1].Value.ToString();

                    nbrSoluong.Value = int.Parse(row.Cells[3].Value.ToString());
                    txtGia.Text = row.Cells[4].Value.ToString();

                    checkupdate = true;
                }
            }
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
                int idBill = int.Parse(txtMabillinfo.Text);
                BanHangBLL.Instance.deleteBillInfo(idBill);
                int id = int.Parse(txtId.Text);
                BanHangBLL.Instance.getBillInfo(dtgvBillbaninfo, id);
                txtMabillinfo.Text = null;
                checkupdate = false;
                nbrSoluong.Value = 0;
                Tongtien();
                kiemtra();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int sl = (int)nbrSoluong.Value;
            if (sl > 0)
            {
                int idBill = int.Parse(txtMabillinfo.Text);
                int soluong = (int)nbrSoluong.Value;

                bool kt = BanHangBLL.Instance.updateProduct(idBill, soluong);
                if (kt == false) MessageBox.Show("Lỗi! Kho hàng không hợp lệ sau khi update");
                int id = int.Parse(txtId.Text);
                BanHangBLL.Instance.getBillInfo(dtgvBillbaninfo, id);
                txtMabillinfo.Text = null;
                checkupdate = false;
                nbrSoluong.Value = 0;
                Tongtien();
                kiemtra();
            }
            else MessageBox.Show("Số lượng phải lớn hơn 0!");
        }

        private void dtgvBillban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvBillban.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvBillban.Rows[e.RowIndex];
                    txtId.Text = row.Cells[0].Value.ToString();
                    if(row.Cells[1].Value!=null)
                    cbMaKH.Text = row.Cells[1].Value.ToString();

                    dateNgayban.Value = (DateTime)row.Cells[3].Value;
                    txtThanhtoan.Text = row.Cells[2].Value.ToString();
                    
                    int id = int.Parse(txtId.Text);
                    BanHangBLL.Instance.getBillInfo(dtgvBillbaninfo, id);

                    dtgvBillbaninfo.Columns[0].HeaderText = "Mã số";
                    dtgvBillbaninfo.Columns[1].HeaderText = "Mã SP";
                    dtgvBillbaninfo.Columns[2].HeaderText = "Tên sản phẩm";
                    dtgvBillbaninfo.Columns[3].HeaderText = "Số lượng";
                    dtgvBillbaninfo.Columns[4].HeaderText = "Giá bán";
  
                    dtgvBillbaninfo.Columns[5].HeaderText = "Thành tiền";



                    dtgvBillbaninfo.Columns[0].Width = 80;
                    dtgvBillbaninfo.Columns[1].Width = 80;
                    dtgvBillbaninfo.Columns[2].Width = 300;
                    dtgvBillbaninfo.Columns[3].Width = 80;
                    dtgvBillbaninfo.Columns[4].Width = 150;
                
                    dtgvBillbaninfo.Columns[5].Width = 150;

                }
            }
            kiemtra();

            Tongtien();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
         "Bạn có chắc chắn muốn xóa?",
         "Warning",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int id = int.Parse(txtId.Text);
                BanHangBLL.Instance.deleteBillTo(id);
                BanHangBLL.Instance.loadBillExport(dtgvBillban);
                txtId.Text = null;
                txtMabillinfo.Text = null;
                checkupdate = false;

                dtgvBillbaninfo.DataSource = null;
                txtTongtien.Text = null;
                kiemtra();
            }

        }

        private void Tongtien()
        {
            float total = 0;
            
            foreach (DataGridViewRow row in dtgvBillbaninfo.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null && float.TryParse(row.Cells["ThanhTien"].Value.ToString(), out float value))
                {
                    total += value;
                }
            }
            txtTongtien.Text = total.ToString("F0");

        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {

                BanHangBLL.Instance.updateIdcus(int.Parse(txtId.Text), int.Parse(cbMaKH.Text));
                //Thread.Sleep(2000);

                int id = int.Parse(txtId.Text);

                BanHangBLL.Instance.getBillInfo(dtgvBillbaninfo, id);


                dtgvBillbaninfo.Columns[0].HeaderText = "Mã số";
                dtgvBillbaninfo.Columns[1].HeaderText = "Mã SP";
                dtgvBillbaninfo.Columns[2].HeaderText = "Tên sản phẩm";
                dtgvBillbaninfo.Columns[3].HeaderText = "Số lượng";
                dtgvBillbaninfo.Columns[4].HeaderText = "Giá bán";
         
                dtgvBillbaninfo.Columns[5].HeaderText = "Thành tiền";



                dtgvBillbaninfo.Columns[0].Width = 80;
                dtgvBillbaninfo.Columns[1].Width = 80;
                dtgvBillbaninfo.Columns[2].Width = 300;
                dtgvBillbaninfo.Columns[3].Width = 80;
                dtgvBillbaninfo.Columns[4].Width = 150;

                dtgvBillbaninfo.Columns[5].Width = 150;
                Tongtien();
            }
        }
    }
}

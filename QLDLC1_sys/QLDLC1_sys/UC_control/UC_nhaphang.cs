using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDLC1_sys.UC_control
{
    public partial class UC_nhaphang : UserControl
    {
        public UC_nhaphang()
        {
            InitializeComponent();
            TrangnhaphangBLL.Instance.loadIdSanPham(cbId);
            cbTen.DataSource = cbId.DataSource;
            cbTen.DisplayMember = "ProductName";
            cbId.DisplayMember = "ProductId";

            LichsunhapBLL.Instance.loadBillImport(dtgvBillnhap);
            dtgvBillnhap.Columns[0].HeaderText = "Mã bill";
            dtgvBillnhap.Columns[1].HeaderText = "Nhà SX";
            dtgvBillnhap.Columns[2].HeaderText = "Thanh toán";

            dtgvBillnhap.Columns[3].HeaderText = "Thời gian";
            dtgvBillnhap.Columns[0].Width = 80;
            dtgvBillnhap.Columns[1].Width = 150;
            dtgvBillnhap.Columns[2].Width = 150;

            dtgvBillnhap.Columns[3].Width = 300;
            ThemnhaSXBLL.Instance.cboNhaSX(cboNhaSX);
            cboNhaSX.DisplayMember = "NhaSXName";
            cboSDT.DataSource = cboNhaSX.DataSource;
            cboEmail.DataSource=cboNhaSX.DataSource;
            cboSDT.DisplayMember = "NhaSXSDT";
            cboEmail.DisplayMember = "NhaSXEmail";
            kiemtra();




        }
        public bool checkupdate = false;
        private void kiemtra()
        {
            if ((txtMabill.Text) == null || (txtMabill.Text == ""))
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            if ((txtId.Text) == null || (txtId.Text == ""))
            {
                btnThem.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                
            }
            else
            {
                btnThem.Enabled = true;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
              
            }

        }
        private void kiemtranhap()
        {
            if(txtId.Text=="")
            {
                cboNhaSX.Enabled = true;
                cboSDT.Enabled = true;
                cboEmail.Enabled = true;
             
            }   
            else
            {
                cboNhaSX.Enabled = false;
                cboSDT.Enabled = false;
                cboEmail.Enabled = false;
            }    
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Themsanpham themsanpham = new Themsanpham();
            themsanpham.ShowDialog();
            TrangnhaphangBLL.Instance.loadIdSanPham(cbId);
            cbTen.DataSource = cbId.DataSource;
            cbTen.DisplayMember = "ProductName";
            cbId.DisplayMember = "ProductId";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {   
            NhaSX nh=cboNhaSX.SelectedItem as NhaSX;    

            BillImport bill = TrangnhaphangBLL.Instance.taoHoaDon(nh.NhaSXId,dateNhap.Value);
            txtId.Text = bill.BillImportId.ToString();
            dateNhap.Value = bill.BillImportDate;
            int id=int.Parse(txtId.Text);
            TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
            dtgvBillInfo.Columns[0].HeaderText = "Mã số";
            dtgvBillInfo.Columns[1].HeaderText = "Mã SP";
            dtgvBillInfo.Columns[2].HeaderText = "Tên sản phẩm";
            dtgvBillInfo.Columns[3].HeaderText = "Số lượng";
            dtgvBillInfo.Columns[4].HeaderText = "Giá sản phẩm";
            dtgvBillInfo.Columns[5].HeaderText = "Thành tiền";



            dtgvBillInfo.Columns[0].Width = 80;
            dtgvBillInfo.Columns[1].Width = 80;
            dtgvBillInfo.Columns[2].Width = 300;
            dtgvBillInfo.Columns[3].Width = 80;
            dtgvBillInfo.Columns[4].Width = 150;
            dtgvBillInfo.Columns[5].Width = 150;
            kiemtranhap();
            kiemtra();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
          "Bạn có chắc chắn muốn xóa?",
          "Warning",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int id = int.Parse(txtId.Text);
                TrangnhaphangBLL.Instance.huyHoaDon(id);
                txtId.Text = null;
                dtgvBillInfo.DataSource = null;
                txtTongtien.Text = null;
                LichsunhapBLL.Instance.loadBillImport(dtgvBillnhap);
                txtMabill.Text =null;
                checkupdate = false;
                txtThanhtoan.Text = null;
                txtTongtien.Text = null;
                dtgvBillInfo.DataSource = null;
                kiemtra();
                kiemtranhap();

            }

        }

        private void UC_nhaphang_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int sl = (int)nbrSoluong.Value;
            if ((sl > 0) && (txtGia.Text != ""))
            {
                int idBill = int.Parse(txtId.Text);
                int product = int.Parse(cbId.Text);
                int soluong = (int)nbrSoluong.Value;
                TrangnhaphangBLL.Instance.addBillInfo(idBill, product, soluong);

                TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, idBill);
                txtMabill.Text = null;
                checkupdate = false;

            
                nbrSoluong.Value = 0;
                Tongtien();
            }
            else MessageBox.Show("Số lượng phải lớn hơn 0 và giá nhập không được để trống!");

        }

        private void dtgvBillInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkupdate=false;
            Int32 selectedRowCount = dtgvBillInfo.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvBillInfo.Rows[e.RowIndex];
                    txtMabill.Text = row.Cells[0].Value.ToString();
                    cbId.Text = row.Cells[1].Value.ToString();
                    
                    nbrSoluong.Value = int.Parse(row.Cells[4].Value.ToString());
                    txtGia.Text = row.Cells[3].Value.ToString();
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
                int idBill = int.Parse(txtMabill.Text);
                bool kt= TrangnhaphangBLL.Instance.deleteBillInfo(idBill);
                if (kt == false) MessageBox.Show("Lỗi! Số sản phẩm trong kho không hợp lệ sau khi xóa");

                int id = int.Parse(txtId.Text);
                TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
                txtMabill.Text = null;
                checkupdate = false;

            
                nbrSoluong.Value = 0;
                Tongtien();
                kiemtra();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            int idBill = int.Parse(txtMabill.Text);
            int product = int.Parse(cbId.Text);
            int soluong = (int)nbrSoluong.Value;
            float gianhap = float.Parse(txtGia.Text);
            bool kt=TrangnhaphangBLL.Instance.updateProduct(idBill, soluong);
            if(kt==false) MessageBox.Show("Lỗi! Số sản phẩm trong kho không hợp lệ sau khi update");
            int id=int.Parse(txtId.Text);
            TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
            txtMabill.Text = null;
            checkupdate = false;

   
            nbrSoluong.Value = 0;
            Tongtien();
            kiemtra();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            float thanhtoan;
            if (txtThanhtoan.Text == "") thanhtoan = 0;
            else thanhtoan = float.Parse(txtThanhtoan.Text);
            TrangnhaphangBLL.Instance.luuBill(int.Parse(txtId.Text),dateNhap.Value,thanhtoan);
            checkupdate = false;
            txtMabill.Text=null;
            txtId.Text=null;
            LichsunhapBLL.Instance.loadBillImport(dtgvBillnhap);
            txtThanhtoan.Text = null;
            txtTongtien.Text = null;
            dtgvBillInfo.DataSource = null;
            kiemtranhap();

        }

        private void dtgvBillnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvBillnhap.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvBillnhap.Rows[e.RowIndex];
                    txtId.Text = row.Cells[0].Value.ToString();
                    cboNhaSX.Text = row.Cells[1].Value.ToString();
                    dateNhap.Value = (DateTime)row.Cells[3].Value;
                    int id = int.Parse(txtId.Text);
                    TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
                    dtgvBillInfo.Columns[0].HeaderText = "Mã số";
                    dtgvBillInfo.Columns[1].HeaderText = "Mã SP";
                    dtgvBillInfo.Columns[2].HeaderText = "Tên sản phẩm";
                    dtgvBillInfo.Columns[3].HeaderText = "Giá";
                    dtgvBillInfo.Columns[4].HeaderText = "Số lượng";
                    dtgvBillInfo.Columns[5].HeaderText = "Thành tiền";



                    dtgvBillInfo.Columns[0].Width = 80;
                    dtgvBillInfo.Columns[1].Width = 80;
                    dtgvBillInfo.Columns[2].Width = 300;
                    dtgvBillInfo.Columns[3].Width =150;
                    dtgvBillInfo.Columns[4].Width = 80;
                    dtgvBillInfo.Columns[5].Width = 150;

                }
            }
            Tongtien();
            kiemtra();
            kiemtranhap();


        }

        private void Tongtien()
        {
            float total = 0;

            foreach (DataGridViewRow row in dtgvBillInfo.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null && float.TryParse(row.Cells["ThanhTien"].Value.ToString(), out float value))
                {
                    total += value;
                }
            }

            txtTongtien.Text = total.ToString("N0", CultureInfo.InvariantCulture); ;

        }

        private void cbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGia.Text = null;
            product pr = cbTen.SelectedItem as product;
            txtGia.Text = pr.ProductPrice.ToString("N0", CultureInfo.InvariantCulture);
            if (checkupdate==true)
            {
                MessageBox.Show("Chỉ có thể update số lượng!");
                txtMabill.Text = null;
                checkupdate = false;
                nbrSoluong.Value = 0;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {  ThemnhaSX mh=new ThemnhaSX();
            mh.ShowDialog();

        }

        private void cboNhaSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiachi.Text = "";
            txtChietkhau.Text = "";
            NhaSX nh=cboNhaSX.SelectedItem as NhaSX;
            if (nh != null) {
                txtDiachi.Text = nh.wards.full_name + ", "+nh.districts.full_name + ", "+nh.provinces.full_name;
                TrangnhaphangBLL.Instance.loadIdSanPham2(cbId,nh.NhaSXId);
                cbTen.DataSource = cbId.DataSource;
                cbTen.DisplayMember = "ProductName";
                cbId.DisplayMember = "ProductId";
                txtChietkhau.Text = nh.NhaSXChietkhau.ToString();
            }

        }

        private void txtThanhtoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtId.Text = null;
            txtThanhtoan.Text = null;
            txtTongtien.Text = null;
            dtgvBillInfo.DataSource = null;
            kiemtranhap();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

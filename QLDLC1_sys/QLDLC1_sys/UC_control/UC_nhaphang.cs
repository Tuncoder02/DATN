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
            dtgvBillnhap.Columns[1].HeaderText = "Thời gian";
            dtgvBillnhap.Columns[0].Width = 80;
            dtgvBillnhap.Columns[1].Width = 300;
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
            BillImport bill = TrangnhaphangBLL.Instance.taoHoaDon();
            txtId.Text = bill.BillImportId.ToString();
            dateNhap.Value = bill.BillImportDate;
            int id=int.Parse(txtId.Text);
            TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
            dtgvBillInfo.Columns[0].HeaderText = "Mã số";
            dtgvBillInfo.Columns[1].HeaderText = "Mã SP";
            dtgvBillInfo.Columns[2].HeaderText = "Tên sản phẩm";
            dtgvBillInfo.Columns[3].HeaderText = "Số lượng";
            dtgvBillInfo.Columns[4].HeaderText = "Giá nhập";
            dtgvBillInfo.Columns[5].HeaderText = "Thành tiền";



            dtgvBillInfo.Columns[0].Width = 80;
            dtgvBillInfo.Columns[1].Width = 80;
            dtgvBillInfo.Columns[2].Width = 300;
            dtgvBillInfo.Columns[3].Width = 80;
            dtgvBillInfo.Columns[4].Width = 150;
            dtgvBillInfo.Columns[5].Width = 150;
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
                txtMabill.Text = null;
                checkupdate = false;
                kiemtra();
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
                float gianhap = float.Parse(txtGia.Text);
                TrangnhaphangBLL.Instance.addBillInfo(idBill, product, soluong, gianhap);

                TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, idBill);
                txtMabill.Text = null;
                checkupdate = false;

                txtGia.Text = null;
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
                int idBill = int.Parse(txtMabill.Text);
                bool kt= TrangnhaphangBLL.Instance.deleteBillInfo(idBill);
                if (kt == false) MessageBox.Show("Lỗi! Số sản phẩm trong kho không hợp lệ sau khi xóa");

                int id = int.Parse(txtId.Text);
                TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
                txtMabill.Text = null;
                checkupdate = false;

                txtGia.Text = null;
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
            bool kt=TrangnhaphangBLL.Instance.updateProduct(idBill, soluong, gianhap);
            if(kt==false) MessageBox.Show("Lỗi! Số sản phẩm trong kho không hợp lệ sau khi update");
            int id=int.Parse(txtId.Text);
            TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
            txtMabill.Text = null;
            checkupdate = false;

            txtGia.Text = null;
            nbrSoluong.Value = 0;
            Tongtien();
            kiemtra();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            TrangnhaphangBLL.Instance.luuBill(int.Parse(txtId.Text));
            checkupdate = true;
            txtMabill.Text=null;
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
                    dateNhap.Value = (DateTime)row.Cells[1].Value;
                    int id = int.Parse(txtId.Text);
                    TrangnhaphangBLL.Instance.getBillInfo(dtgvBillInfo, id);
                    dtgvBillInfo.Columns[0].HeaderText = "Mã số";
                    dtgvBillInfo.Columns[1].HeaderText = "Mã SP";
                    dtgvBillInfo.Columns[2].HeaderText = "Tên sản phẩm";
                    dtgvBillInfo.Columns[3].HeaderText = "Số lượng";
                    dtgvBillInfo.Columns[4].HeaderText = "Giá nhập";
                    dtgvBillInfo.Columns[5].HeaderText = "Thành tiền";



                    dtgvBillInfo.Columns[0].Width = 80;
                    dtgvBillInfo.Columns[1].Width = 80;
                    dtgvBillInfo.Columns[2].Width = 300;
                    dtgvBillInfo.Columns[3].Width = 80;
                    dtgvBillInfo.Columns[4].Width = 150;
                    dtgvBillInfo.Columns[5].Width = 150;

                }
            }
            Tongtien();
            kiemtra();


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

            txtTongtien.Text = total.ToString("F0");

        }

        private void cbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(checkupdate==true)
            {
                MessageBox.Show("Chỉ có thể update số lượng hoặc giá nhập!");
                txtMabill.Text = null;
                checkupdate = false;
                nbrSoluong.Value = 0;
                txtGia.Text = null;
            }
        }
    }
}

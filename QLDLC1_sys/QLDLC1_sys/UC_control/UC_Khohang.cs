using BLL;
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

namespace QLDLC1_sys.UC_control
{
    public partial class UC_Khohang : UserControl
    {
        public UC_Khohang()
        {
             
            InitializeComponent();
            KhoHangBLL.Instance.showSanpham(dtgvSanPham);
            dtgvSanPham.Columns[0].HeaderText = "Mã SP";
            dtgvSanPham.Columns[1].HeaderText = "Nhóm sản phẩm";
            dtgvSanPham.Columns[2].HeaderText = "Tên sản phẩm";
            dtgvSanPham.Columns[3].HeaderText = "Giá";
            dtgvSanPham.Columns[4].HeaderText = "Số lượng";
            dtgvSanPham.Columns[5].HeaderText = "Mô tả";
            dtgvSanPham.Columns[6].HeaderText = "Link ảnh";


            dtgvSanPham.Columns[0].Width = 60;
            dtgvSanPham.Columns[1].Width = 150;
            dtgvSanPham.Columns[2].Width = 250;
            dtgvSanPham.Columns[3].Width = 200;
            dtgvSanPham.Columns[4].Width = 100;
            dtgvSanPham.Columns[5].Width = 500;
            dtgvSanPham.Columns[6].Width = 500;
            lbpath.Text = "ngu";
            kiemtra();
        }
        private void kiemtra()
        {
            if((txtMaSP.Text)==null||(txtMaSP.Text==""))
            {
                btnCapNhat.Enabled = false;
                btnXoa.Enabled = false;
            }
            else 
            {
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        private OpenFileDialog openFileDialog1=new OpenFileDialog();
        private string path=null;
        private string newPath=null;
        private TextBox lbpath=new TextBox();
        private void UC_Khohang_Load(object sender, EventArgs e)
        {
         
            KhoHangBLL.Instance.loadProductGroup(cbNhomsanpham);
        }

        private void cbNhomsanpham_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbNhomsanpham.SelectedItem != null)
            {
                KhoHangBLL.Instance.filterProduct(cbNhomsanpham, dtgvSanPham);
            }
            else KhoHangBLL.Instance.showSanpham(dtgvSanPham);

        }

        private void dtgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvSanPham.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvSanPham.Rows[e.RowIndex];
                    txtMaSP.Text = row.Cells[0].Value.ToString();
                    txtTensanpham.Text = row.Cells[2].Value.ToString();
                    txtGiasanpham.Text = row.Cells[3].Value.ToString();
                    nbrSoluong.Value = int.Parse(row.Cells[4].Value.ToString());
                   
                    //SanPhamBUS.Instance.showImageToPictureBox(row.Cells[7].Value.ToString(), pictureLinhKien);
                   
                    txtMota.Text = row.Cells[5].Value.ToString();
                    lbpath.Text = "null";
                    if(row.Cells[6].Value!=null)
                    lbpath.Text = row.Cells[6].Value.ToString();
                    KhoHangBLL.Instance.showImageToPictureBox(lbpath.Text, ptrboxAnh);
                    cbNhomsanpham.Text = row.Cells[1].Value.ToString();

                }
            }
            kiemtra();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = null;
            txtGiasanpham.Text = null;
            txtMota.Text=null;
            txtTensanpham.Text = null;
            nbrSoluong.Value = 0;
            cbNhomsanpham.Text=null;
            ptrboxAnh.Image = null;
            kiemtra();

        }
        private static bool isSortedAscending = false;

        private void dtgvSanPham_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dtgvSanPham.Columns[e.ColumnIndex];
            // Thực hiện sắp xếp dựa trên cột được nhấp
            if (column.Name == "TenSanPham") // Sắp xếp theo tên sản phẩm
            {
                if (!isSortedAscending)
                {
                    // Sắp xếp giảm dần nếu đang ở trạng thái tăng dần
                    KhoHangBLL.Instance.sortProductByNameAscending(dtgvSanPham);
                    isSortedAscending = true;


                }
                else
                {
                    KhoHangBLL.Instance.sortProductByNameDescending(dtgvSanPham);
                    isSortedAscending = false;


                }
            }
            else
                if (column.Name == "GiaSanPham") // Sắp xếp theo tên sản phẩm
                {
                    if (!isSortedAscending)
                    {
                        // Sắp xếp giảm dần nếu đang ở trạng thái tăng dần
                        KhoHangBLL.Instance.sortProductByPriceAscending(dtgvSanPham);
                        isSortedAscending = true;


                    }
                    else
                    {
                        KhoHangBLL.Instance.sortProductByPriceDescending(dtgvSanPham);
                        isSortedAscending = false;


                    }
                }

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
                int id = Convert.ToInt32(txtMaSP.Text);
                KhoHangBLL.Instance.deleteProduct(id);
                button2_Click(sender, e);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            if ((txtGiasanpham.Text != "") && (txtTensanpham.Text != ""))
            {
                int id = Convert.ToInt32(txtMaSP.Text);
                string name = txtTensanpham.Text;
                string info = txtMota.Text;
                int quantity = Convert.ToInt32(nbrSoluong.Value);
                float price = float.Parse(txtGiasanpham.Text);

                KhoHangBLL.Instance.updateProduct(id, name, price, quantity, info, lbpath.Text);
                button2_Click(sender, e);

            } else MessageBox.Show("Không được để trống thông tin!");


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"D:\C#\codehoc\QLDLC1_sys\QLDLC1_sys\image";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select image to be upload.";
            //which type image format you want to upload in database. just add them.
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                        lbpath.Text = path;
                        ptrboxAnh.Image = new Bitmap(openFileDialog1.FileName);
                        ptrboxAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }

        }
    }
}

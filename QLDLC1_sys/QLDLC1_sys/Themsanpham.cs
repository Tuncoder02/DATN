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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDLC1_sys
{
    public partial class Themsanpham : Form
    {
        public Themsanpham()
        {
            InitializeComponent();
            KhoHangBLL.Instance.loadProductGroup(cbNhomsanpham);
            lbpath.Text = "0";


        }

        private void ptrboxAnh_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Themnhom themnhom = new Themnhom();
            themnhom.ShowDialog();
            KhoHangBLL.Instance.loadProductGroup(cbNhomsanpham);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTensanpham_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if ((txtGiasanpham.Text != "") && (txtTensanpham.Text != ""))
            {
                productgroup selectedItem = (productgroup)cbNhomsanpham.SelectedItem;
                int pg = selectedItem.ProductGroupId;
                string ten = txtTensanpham.Text;
                float gia = float.Parse(txtGiasanpham.Text);
                string mota = txtMota.Text;
                SanphamBLL.Instance.addSanpham(pg, ten, gia, mota, lbpath.Text);
                this.Close();
            }
            else MessageBox.Show("Hãy điền đầy đủ thông tin trước khi bấm!");
        }
        private OpenFileDialog openFileDialog1=new OpenFileDialog();
        private string path = null;
        private System.Windows.Forms.TextBox lbpath =new System.Windows.Forms.TextBox();
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

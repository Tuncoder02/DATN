using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDLC1_sys
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "" || txtMatkhau.Text != "")
            {
                DangNhapBLL dn = new DangNhapBLL();
                if (dn.checkLogin(txtTaiKhoan.Text, txtMatkhau.Text))
                {
                    Trangchu f = new Trangchu();
                    this.Hide();
                    f.ShowDialog();
                }
                else MessageBox.Show("Email hoặc mật khẩu không hợp lệ", "Thông Báo", MessageBoxButtons.OK);

            }
            else MessageBox.Show("Vui lòng nhập Email và Password!", "Thông Báo", MessageBoxButtons.OK);
        }
    }
}

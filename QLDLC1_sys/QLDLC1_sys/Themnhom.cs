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
    public partial class Themnhom : Form
    {
        public Themnhom()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTennhom.Text != "")
            {
                NhomBLL.Instance.addProductGroup(txtTennhom.Text);
                this.Close();
            }
            else MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
        }
    }
}

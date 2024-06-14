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
    public partial class Daily : Form
    {
        public Daily()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DailyBLL.Instance.themloaidaily(txtTen.Text, float.Parse(txtChietkhau.Text));

        }
    }
}

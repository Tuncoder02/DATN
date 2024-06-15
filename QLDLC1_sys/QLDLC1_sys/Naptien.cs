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
    public partial class Naptien : Form
    {
        public Naptien()
        {
            InitializeComponent();
            NaptienBLL.Instance.getNap(dtgvPhieuthu);

            dtgvPhieuthu.Columns[0].HeaderText = "Mã";
            dtgvPhieuthu.Columns[1].HeaderText = "Số tiền";
            dtgvPhieuthu.Columns[2].HeaderText = "Nội dung ";
            dtgvPhieuthu.Columns[3].HeaderText = "Ngày nạp";
           


            dtgvPhieuthu.Columns[0].Width = 80;
            dtgvPhieuthu.Columns[1].Width = 100;
            dtgvPhieuthu.Columns[2].Width = 100;
            dtgvPhieuthu.Columns[3].Width = 100;
          
            kiemtra();
        }
        private void kiemtra()
        {
            if(txtMaphieu.Text=="")
            {
               btnSua.Enabled = false;
               btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa .Enabled = true;
            }
        }
        private bool kiemtraluu()
        {
            if (txtSotien.Text == "") return false;
            if (txtNoidung.Text == "") return false;
            return true;
        }
        private void Naptien_Load(object sender, EventArgs e)
        {

        }

        private void dtgvPhieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dtgvPhieuthu.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dtgvPhieuthu.Rows[e.RowIndex];
                    txtMaphieu.Text = row.Cells[0].Value.ToString();
                    
                    txtSotien.Text = row.Cells[1].Value.ToString();

                    txtNoidung.Text = row.Cells[2].Value.ToString();
                    dateNgayThu.Value = (DateTime)row.Cells[3].Value;

                }
            }
            kiemtra();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaphieu.Text = "";
            txtSotien.Text = "";
            txtNoidung.Text = "";
            NaptienBLL.Instance.getNap(dtgvPhieuthu);

            dtgvPhieuthu.Columns[0].HeaderText = "Mã";
            dtgvPhieuthu.Columns[1].HeaderText = "Số tiền";
            dtgvPhieuthu.Columns[2].HeaderText = "Nội dung ";
            dtgvPhieuthu.Columns[3].HeaderText = "Ngày nạp";



            dtgvPhieuthu.Columns[0].Width = 80;
            dtgvPhieuthu.Columns[1].Width = 100;
            dtgvPhieuthu.Columns[2].Width = 100;
            dtgvPhieuthu.Columns[3].Width = 100;

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
              int id=int.Parse(txtMaphieu.Text);
                NaptienBLL.Instance.removeNap(id);
                btnLammoi_Click(sender, e);


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kiemtraluu() == true)
            {
                NaptienBLL.Instance.editNap(int.Parse(txtMaphieu.Text),float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
                btnLammoi_Click(sender, e);

            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemtraluu() == true)
            {
                NaptienBLL.Instance.addNap(float.Parse(txtSotien.Text), txtNoidung.Text, dateNgayThu.Value);
               btnLammoi_Click(sender, e);
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }
    }
}

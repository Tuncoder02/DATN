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
using System.Windows.Forms.DataVisualization.Charting;

namespace QLDLC1_sys
{
    public partial class Kiemtradaily : Form
    {
        public Kiemtradaily()
        {
            InitializeComponent();
            DiagioiBLL.Instance.loadProvinces(cboTinh);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHuyen.Items.Clear();
            cboHuyen.Text = null;
            DiagioiBLL.Instance.loadDistricts(cboTinh, cboHuyen);
            if (cboTinh.SelectedItem != null) {
                provinces pr = cboTinh.SelectedItem as provinces;
                string oke = Requestdanso.ConvertToUpperNoDiacritics(pr.name);
                enumtinh en;
                
                int x = 0;
                if (Enum.TryParse(oke, out en))
                {
                    // Lấy giá trị số nguyên của enum
                    x = (int)en;
                    Requestdanso.PostRequestAsync(x.ToString(), txtDientich, txtDanso, txtMatDo);
                    //  Console.WriteLine("Giá trị số nguyên của " + en + " là: " + diaPhuongValue);
                }
                else
                {
                    
                }
                chartXa.Series[0].Points.Clear();
                dtgvXa.DataSource = null;
                KiemtradailyBLL.Instance.loadHuyen(dtgvHuyen,chartHuyen, pr.code);
                dtgvHuyen.Columns[0].HeaderText = "Huyện";
                dtgvHuyen.Columns[1].HeaderText = "Số đại lý";
                dtgvHuyen.Columns[2].HeaderText = "số khách";
                dtgvHuyen.Columns[3].HeaderText = "Bán ra";



                dtgvHuyen.Columns[0].Width = 120;
                dtgvHuyen.Columns[1].Width = 100;
                dtgvHuyen.Columns[2].Width = 100;
                dtgvHuyen.Columns[3].Width = 100;



            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dtgvHuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cboHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            districts dt=cboHuyen.SelectedItem as districts;
            KiemtradailyBLL.Instance.loadXa(dtgvXa, chartXa, dt.code);
            dtgvXa.Columns[0].HeaderText = "Xã";
            dtgvXa.Columns[1].HeaderText = "Số đại lý";
            dtgvXa.Columns[2].HeaderText = "số khách";
            dtgvXa.Columns[3].HeaderText = "Bán ra";
            dtgvXa.Columns[0].Width = 120;
            dtgvXa.Columns[1].Width = 100;
            dtgvXa.Columns[2].Width = 100;
            dtgvXa.Columns[3].Width = 100;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace QLDLC1_sys.UC_control
{
    public partial class UC_Thongketongquan : UserControl
    {
        public UC_Thongketongquan()
        {
            InitializeComponent();
            DateTime startDate = new DateTime(2023, 1, 1); 
            DateTime endDate =DateTime.Now;
            TongquanthongkeBLL.Instance.loadSPNhap(chartNhap, startDate, endDate);
            TongquanthongkeBLL.Instance.loadSPXuat(chartXuat,startDate, endDate);
            TongquanthongkeBLL.Instance.loadTon(chartTon, endDate);
            TongquanthongkeBLL.Instance.loadKhachhang(chartKhachhang, startDate, endDate);
            loaddtgv(startDate,endDate);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void loaddtgv(DateTime startDate,DateTime endDate)
        {
            TongquanthongkeBLL.Instance.loadTien(dtgvTien, startDate, endDate);
            dtgvTien.Columns[0].HeaderText = "Mã SP";
            dtgvTien.Columns[1].HeaderText = "Tên SP";
            dtgvTien.Columns[2].HeaderText = "Tiền nhập";
            dtgvTien.Columns[3].HeaderText = "Tiền xuất";
            dtgvTien.Columns[0].Width = 80;
            dtgvTien.Columns[1].Width = 150;
            dtgvTien.Columns[2].Width = 100;
            dtgvTien.Columns[3].Width = 300;
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
        
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_Thongketongquan_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTraCuu_Click_1(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, dateTuNgay.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dateDenNgay.Value.Year, dateDenNgay.Value.Month, dateDenNgay.Value.Day, 23, 59, 59);

            TongquanthongkeBLL.Instance.loadSPNhap(chartNhap, startDate, endDate);
            TongquanthongkeBLL.Instance.loadSPXuat(chartXuat, startDate, endDate);
            TongquanthongkeBLL.Instance.loadTon(chartTon, endDate);
            TongquanthongkeBLL.Instance.loadKhachhang(chartKhachhang, startDate, endDate);
            loaddtgv(startDate, endDate);
        }
    }
}

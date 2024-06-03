using QLDLC1_sys.UC_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDLC1_sys
{
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }
        private Form Currentchildform;
        private void Openchildform(Form childForm)
        {
              if(Currentchildform != null) { Currentchildform.Close(); }
              Currentchildform = childForm;
              childForm.TopLevel = false;
              childForm.FormBorderStyle = FormBorderStyle.None;
              childForm.Dock = DockStyle.Fill;
              panelBody.Controls.Add(childForm);
              panelBody.Tag= childForm;
              childForm.BringToFront();
              childForm.Show();
        }
        private void showControl(Control ctrl)
        {
            panelBody.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            panelBody.Controls.Add(ctrl);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnTongquan.ForeColor= SystemColors.ControlText;
            btnTongquan.BackColor = SystemColors.ControlLightLight;
            btnTongquan.Image = Image.FromFile(defaultImagePath);
            UC_Khohang uc =new UC_Khohang();
            showControl(uc);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor= Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);

           
            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);

           
            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);

           
            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);

            
            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);

            
            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);

            
            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);

            
            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);

           
            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);

            
            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);

          
            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);

         
            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);




        }

        private void Trangchu_Load(object sender, EventArgs e)
        {

        }
        bool KhohangExpand=false;
        private void Khohangtrans_Tick(object sender, EventArgs e)
        {
            if(KhohangExpand==false)
            {
                KhohangMenu.Height += 10;
                if(KhohangMenu.Height >=178)
                {
                    Khohangtrans.Stop();
                    KhohangExpand = true;
                }
            }
            else
            {
                KhohangMenu.Height -= 10;
                if(KhohangMenu.Height <=67)
                {
                    Khohangtrans.Stop();
                    KhohangExpand = false;
                }
            }
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Khohangtrans.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Slidemenutrans.Start();
        }
        bool SlideExpand = false;
        private void Slidemenutrans_Tick(object sender, EventArgs e)
        {
            if (SlideExpand == false)
            {
                SlideMenu.Width += 10;
                if (SlideMenu.Width >= 272)
                {
                    Slidemenutrans.Stop();
                    SlideExpand = true;
                }
            }
            else
            {
                SlideMenu.Width -= 10;
                if (SlideMenu.Width <= 71)
                {
                    Slidemenutrans.Stop();
                    SlideExpand = false;
                }
            }
        }

        private void KhohangMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        bool BanhangExpand=false;
        private void Banhangtrans_Tick(object sender, EventArgs e)
        {
            if (BanhangExpand == false)
            {
                BanhangMenu.Height += 10;
                if (BanhangMenu.Height >= 122)
                {
                    Banhangtrans.Stop();
                    BanhangExpand = true;
                }
            }
            else
            {
                BanhangMenu.Height -= 10;
                if (BanhangMenu.Height <= 67)
                {
                    Banhangtrans.Stop();
                    BanhangExpand = false;
                }
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Banhangtrans.Start();

        }

        private void SlideMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        bool CongnoExpand = false;
        private void Congnotrans_Tick(object sender, EventArgs e)
        {
            if (CongnoExpand == false)
            {
                CongnoMenu.Height += 10;
                if (CongnoMenu.Height >= 189)
                {
                    Congnotrans.Stop();
                    CongnoExpand = true;
                }
            }
            else
            {
                CongnoMenu.Height -= 10;
                if (CongnoMenu.Height <= 67)
                {
                    Congnotrans.Stop();
                    CongnoExpand = false;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Congnotrans.Start();
        }
        bool ThongkeExpand = false;

        private void Thongketrans_Tick(object sender, EventArgs e)
        {

            if (ThongkeExpand == false)
            {
                ThongkeMenu.Height += 10;
                if (ThongkeMenu.Height >= 249)
                {
                    Thongketrans.Stop();
                    ThongkeExpand = true;
                }
            }
            else
            {
                ThongkeMenu.Height -= 10;
                if (ThongkeMenu.Height <= 67)
                {
                    Thongketrans.Stop();
                    ThongkeExpand = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thongketrans.Start();
        }
        bool KhachhangExpand = false;
        private void Khachhangtrans_Tick(object sender, EventArgs e)
        {
            if (KhachhangExpand == false)
            {
                KhachhangMenu.Height += 10;
                if (KhachhangMenu.Height >= 178)
                {
                    Khachhangtrans.Stop();
                    KhachhangExpand = true;
                }
            }
            else
            {
                KhachhangMenu.Height -= 10;
                if (KhachhangMenu.Height <= 67)
                {
                    Khachhangtrans.Stop();
                    KhachhangExpand = false;
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Khachhangtrans.Start();
        }

        private void btnNhaphang_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnNhaphang.ForeColor = SystemColors.ControlText;
            btnNhaphang.BackColor = SystemColors.ControlLightLight;
            btnNhaphang.Image = Image.FromFile(defaultImagePath);
            UC_nhaphang uc=new UC_nhaphang();
            showControl(uc);
            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnLichsunhap_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnLichsunhap.ForeColor = SystemColors.ControlText;
            btnLichsunhap.BackColor = SystemColors.ControlLightLight;
            btnLichsunhap.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);
            UC_Lichsunhap uc=new UC_Lichsunhap();
            showControl(uc);

            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {


        }

        private void button11_Click(object sender, EventArgs e)
        {
            //taohoadon
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnTaohoadon.ForeColor = SystemColors.ControlText;
            btnTaohoadon.BackColor = SystemColors.ControlLightLight;
            btnTaohoadon.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);

            UC_Hoadonbanhang uc = new UC_Hoadonbanhang();
            showControl(uc);
            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //lichsuban
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnLichsuban.ForeColor = SystemColors.ControlText;
            btnLichsuban.BackColor = SystemColors.ControlLightLight;
            btnLichsuban.Image = Image.FromFile(defaultImagePath);
            UC_Lichsuban uc=new UC_Lichsuban();
            showControl(uc);
            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //btn tk khachhang
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnTKKhachhang.ForeColor = SystemColors.ControlText;
            btnTKKhachhang.BackColor = SystemColors.ControlLightLight;
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnTKDoanhso_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnTKDoanhso.ForeColor = SystemColors.ControlText;
            btnTKDoanhso.BackColor = SystemColors.ControlLightLight;
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnTKSanpham_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnTKSanpham.ForeColor = SystemColors.ControlText;
            btnTKSanpham.BackColor = SystemColors.ControlLightLight;
            btnTKSanpham.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnTongcongno_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnTongcongno.ForeColor = SystemColors.ControlText;
            btnTongcongno.BackColor = SystemColors.ControlLightLight;
            btnTongcongno.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnCongnokhachhang_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnCongnokhachhang.ForeColor = SystemColors.ControlText;
            btnCongnokhachhang.BackColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnQuanly_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnQuanly.ForeColor = SystemColors.ControlText;
            btnQuanly.BackColor = SystemColors.ControlLightLight;
            btnQuanly.Image = Image.FromFile(defaultImagePath);
            UC_Quanlykhachhang uc=new UC_Quanlykhachhang();
            showControl(uc);
            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnDangkyKH_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");
            btnDangkyKH.ForeColor = SystemColors.ControlText;
            btnDangkyKH.BackColor = SystemColors.ControlLightLight;
            btnDangkyKH.Image = Image.FromFile(defaultImagePath);
            UC_HopdongDL uc = new UC_HopdongDL();
            showControl(uc);
            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void btnDangkyDL_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");

            btnDangkyDL.ForeColor = SystemColors.ControlText;
            btnDangkyDL.BackColor = SystemColors.ControlLightLight;
            btnDangkyDL.Image = Image.FromFile(defaultImagePath);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);

        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = SystemColors.GrayText;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = SystemColors.ControlText;
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.BackColor = SystemColors.GrayText;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = SystemColors.ControlText;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.GrayText;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.ControlText;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = SystemColors.GrayText;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = SystemColors.ControlText;
        }

        private void button17_MouseHover(object sender, EventArgs e)
        {
            button17.BackColor = SystemColors.GrayText;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            button17.BackColor = SystemColors.ControlText;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.GrayText;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.ControlText;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath = Path.Combine(appPath, "img", "circle_den.png");


            // Kết hợp đường dẫn tương đối với tên tệp ảnh mặc định
            string defaultImagePath1 = Path.Combine(appPath, "img", "circle.png");
            btnTongquan.ForeColor = SystemColors.ControlLightLight;
            btnTongquan.BackColor = Color.FromArgb(41, 43, 43);
            btnTongquan.Image = Image.FromFile(defaultImagePath1);

            btnQuanly.ForeColor = SystemColors.ControlLightLight;
            btnQuanly.BackColor = Color.FromArgb(41, 43, 43);
            btnQuanly.Image = Image.FromFile(defaultImagePath1);


            btnNhaphang.ForeColor = SystemColors.ControlLightLight;
            btnNhaphang.BackColor = Color.FromArgb(41, 43, 43);
            btnNhaphang.Image = Image.FromFile(defaultImagePath1);


            btnTaohoadon.ForeColor = SystemColors.ControlLightLight;
            btnTaohoadon.BackColor = Color.FromArgb(41, 43, 43);
            btnTaohoadon.Image = Image.FromFile(defaultImagePath1);


            btnTKDoanhso.ForeColor = SystemColors.ControlLightLight;
            btnTKDoanhso.BackColor = Color.FromArgb(41, 43, 43);
            btnTKDoanhso.Image = Image.FromFile(defaultImagePath1);


            btnTKKhachhang.ForeColor = SystemColors.ControlLightLight;
            btnTKKhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnTKKhachhang.Image = Image.FromFile(defaultImagePath1);


            btnTKSanpham.ForeColor = SystemColors.ControlLightLight;
            btnTKSanpham.BackColor = Color.FromArgb(41, 43, 43);
            btnTKSanpham.Image = Image.FromFile(defaultImagePath1);


            btnTongcongno.ForeColor = SystemColors.ControlLightLight;
            btnTongcongno.BackColor = Color.FromArgb(41, 43, 43);
            btnTongcongno.Image = Image.FromFile(defaultImagePath1);


            btnCongnokhachhang.ForeColor = SystemColors.ControlLightLight;
            btnCongnokhachhang.BackColor = Color.FromArgb(41, 43, 43);
            btnCongnokhachhang.Image = Image.FromFile(defaultImagePath1);


            btnDangkyDL.ForeColor = SystemColors.ControlLightLight;
            btnDangkyDL.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyDL.Image = Image.FromFile(defaultImagePath1);


            btnDangkyKH.ForeColor = SystemColors.ControlLightLight;
            btnDangkyKH.BackColor = Color.FromArgb(41, 43, 43);
            btnDangkyKH.Image = Image.FromFile(defaultImagePath1);


            btnLichsuban.ForeColor = SystemColors.ControlLightLight;
            btnLichsuban.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsuban.Image = Image.FromFile(defaultImagePath1);


            btnLichsunhap.ForeColor = SystemColors.ControlLightLight;
            btnLichsunhap.BackColor = Color.FromArgb(41, 43, 43);
            btnLichsunhap.Image = Image.FromFile(defaultImagePath1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

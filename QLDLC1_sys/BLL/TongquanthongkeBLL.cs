using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing; 


namespace BLL
{
    public class TongquanthongkeBLL
    {
        private static TongquanthongkeBLL instance;
        public static TongquanthongkeBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongquanthongkeBLL();
                return instance;
            }
        }

        public void loadSPNhap(Chart chart1, DateTime startDate, DateTime endDate)
        {
            var result = TongquanthongkeDAL.Instance.getSPNhap(startDate, endDate);
            chart1.Series[0].Points.Clear();
            chart1.Annotations.Clear();
            foreach (var item in result)
            {
                var point = chart1.Series[0].Points.Add(item.TongSoLuong);
                point.Label = item.TongSoLuong.ToString();
                point.AxisLabel = item.TenSanPham;
            }
            int totalQuantity = result.Sum(item => item.TongSoLuong);


            var chartArea = chart1.ChartAreas[0];
            var centerX = chartArea.Position.X + chartArea.Position.Width / 2;
            var centerY = chartArea.Position.Y + chartArea.Position.Height / 2;


            var totalAnnotation = new TextAnnotation
            {
                Text = $"{totalQuantity}",
                ForeColor = Color.Black,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                AnchorX = 0,
                AnchorY = 0,
                AnchorAlignment = ContentAlignment.TopLeft,
                X = 5, 
                Y = 5, 
                Alignment = ContentAlignment.TopLeft
            };
            chart1.Annotations.Add(totalAnnotation);
            chart1.Series[0].LegendText = "#AXISLABEL";

        }

        public void loadSPXuat(Chart chart1, DateTime startDate, DateTime endDate)
        {
            var result = TongquanthongkeDAL.Instance.getSPXuat(startDate, endDate);
            chart1.Series[0].Points.Clear();
            chart1.Annotations.Clear();

            foreach (var item in result)
            {
                var point = chart1.Series[0].Points.Add(item.TongSoLuong);
                point.Label = item.TongSoLuong.ToString();
                point.AxisLabel = item.TenSanPham;
            }
            int totalQuantity = result.Sum(item => item.TongSoLuong);


            var chartArea = chart1.ChartAreas[0];
            var centerX = chartArea.Position.X + chartArea.Position.Width / 2;
            var centerY = chartArea.Position.Y + chartArea.Position.Height / 2;


            var totalAnnotation = new TextAnnotation
            {
                Text = $"{totalQuantity}",
                ForeColor = Color.Black,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                AnchorX = 0,
                AnchorY = 0,
                AnchorAlignment = ContentAlignment.TopLeft,
                X = 5, // khoảng cách từ trái
                Y = 5, // khoảng cách từ trên
                Alignment = ContentAlignment.TopLeft
            };
            chart1.Annotations.Add(totalAnnotation);
            chart1.Series[0].LegendText = "#AXISLABEL";

        }
        public void loadTon(Chart chart1, DateTime endDate)
        {
            var result = TongquanthongkeDAL.Instance.getTon(endDate);
            chart1.Series[0].Points.Clear();
            chart1.Legends.Clear(); // Xóa chú thích cũ (nếu có)
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            Color[] colors = new Color[] { Color.Blue, Color.Red, Color.Green, Color.Yellow, Color.Orange, Color.Purple, Color.Gray, Color.Pink };

            int colorIndex = 0; // Chỉ mục của mảng màu

            foreach (var item in result)
            {
                if (item.InventoryQuantity != null)
                {
                    // Thêm một cột mới
                    var point = chart1.Series[0].Points.Add((int)item.InventoryQuantity);

                    // Thiết lập màu cho cột
                    point.Color = colors[colorIndex % colors.Length];
                    colorIndex++;

                    point.Label = item.InventoryQuantity.ToString();
                    // Đặt nhãn dọc
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(point.XValue - 0.5, point.XValue + 0.5, item.ProductName);
                }
            }

            // Tạo chú thích cho màu sắc tương ứng với từng cột
            Legend legend = new Legend();
            chart1.Legends.Add(legend);

            for (int i = 0; i < result.Count; i++)
            {
                var item = result[i];
                if (item.InventoryQuantity != null)
                {
                    string productName = item.ProductName;
                    if (i < colors.Length)
                    {
                        legend.CustomItems.Add(colors[i], productName);
                    }
                    else
                    {
                        legend.CustomItems.Add(colors[i % colors.Length], productName);
                    }
                }
            }
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }
        public void loadKhachhang(Chart chart1,DateTime startDate, DateTime endDate)
        {
            var result = TongquanthongkeDAL.Instance.getKhachhang(startDate,endDate);
            chart1.Series[0].Points.Clear();
            chart1.Legends.Clear(); // Xóa chú thích cũ (nếu có)

            // Tạo một bảng màu đa dạng cho các cột
            Color[] colors = new Color[] { Color.Blue, Color.Red, Color.Green, Color.Yellow, Color.Orange, Color.Purple, Color.Gray, Color.Pink };

            int colorIndex = 0; // Chỉ mục của mảng màu

            foreach (var item in result)
            {
                if (item.TotalProductsSold != null)
                {
                    // Thêm một cột mới
                    var point = chart1.Series[0].Points.Add((int)item.TotalProductsSold);

                    // Thiết lập màu cho cột
                    point.Color = colors[colorIndex % colors.Length];
                    colorIndex++;

                    point.Label = item.TotalProductsSold.ToString();
                    // Đặt nhãn dọc
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(point.XValue - 0.5, point.XValue + 0.5, item.CustomerName);
                }
            }

            // Tạo chú thích cho màu sắc tương ứng với từng cột
            Legend legend = new Legend();
            chart1.Legends.Add(legend);

            for (int i = 0; i < result.Count; i++)
            {
                var item = result[i];
                if (item.TotalProductsSold != null)
                {
                    string productName = item.CustomerName;
                    if (i < colors.Length)
                    {
                        legend.CustomItems.Add(colors[i], productName);
                    }
                    else
                    {
                        legend.CustomItems.Add(colors[i % colors.Length], productName);
                    }
                }
            }
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }

        public void loadTien(DataGridView data, DateTime startDate, DateTime endDate)
        {
            var result = TongquanthongkeDAL.Instance.getNhapxuat(startDate, endDate);
            data.DataSource= result;

        }
    }
}

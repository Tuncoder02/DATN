using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static DAL.KiemtradailyDAL;

namespace BLL
{
    public class KiemtradailyBLL
    {
        private static KiemtradailyBLL instance;
        public static KiemtradailyBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KiemtradailyBLL();
                return instance;
            }
        }

        public void loadHuyen(DataGridView data,Chart chart1 , string provinceid)
        {
            var result= KiemtradailyDAL.Instance.GetCustomersCountByDistrict(provinceid);
            chart1.Series[0].Points.Clear();

            foreach (var item in result)
            {
                var point = chart1.Series[0].Points.Add(item.TotalOrderDetailQuantity);
                point.Label = item.TotalOrderDetailQuantity.ToString();
                point.AxisLabel = item.DistrictName;
            }
            chart1.Series[0].LegendText = "#AXISLABEL";
            data.DataSource= result;
        }
        public void loadXa(DataGridView data, Chart chart1, string id)
        {
            var result = KiemtradailyDAL.Instance.GetCustomersCountByWard(id);
            chart1.Series[0].Points.Clear();

            foreach (var item in result)
            {
                var point = chart1.Series[0].Points.Add(item.TotalOrderDetailQuantity);
                point.Label = item.TotalOrderDetailQuantity.ToString();
                point.AxisLabel = item.WardName;
            }
            chart1.Series[0].LegendText = "#AXISLABEL";
            data.DataSource = result;
        }
    }
}

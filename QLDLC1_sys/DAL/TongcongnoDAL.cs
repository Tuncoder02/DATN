using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static DAL.BanHangDAL;

namespace DAL
{
    public class TongcongnoDAL
    {

        private static TongcongnoDAL instance;
        public static TongcongnoDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TongcongnoDAL();
                return instance;
            }
        }
        public class CongNoReport
        {
            public string TenKhachHang { get; set; }
            public double SoDuDau { get; set; }
            public double SoTienNo { get; set; }
            public double SoThanhToan { get; set; }
            public double SoDuCuoi { get; set; }
        }
        public List<CongNoReport> getCongNoReport(DateTime tuNgay,DateTime denNgay)
        {
            var query = (from kh in DataProvider.Ins.DB.customer
                         where kh.CustomerId > 1
                         select new CongNoReport
                         {
                             TenKhachHang = kh.CustomerFullName,
                             SoDuDau = (double)((from hd in DataProvider.Ins.DB.BillExport
                                                 join hdt in DataProvider.Ins.DB.BillExportDetails on hd.BillExportId equals hdt.BillExportId
                                                 join sp in DataProvider.Ins.DB.product on hdt.ProductId equals sp.ProductId
                                                 from d in DataProvider.Ins.DB.chietkhausp.Where(d => d.CustomerId == kh.CustomerId && d.ProductId == sp.ProductId).DefaultIfEmpty()
                                                 where hd.CustomerId == kh.CustomerId && hd.BillExportDate < tuNgay
                                                 select hdt.Quantity * sp.ProductPrice * (1 - (d != null ? d.chietkhau : 0) / 100) * (1 - (double)hd.BillPayPercent / 100)).Sum() ?? 0
                                           - (from pt in DataProvider.Ins.DB.Receipts
                                              where pt.CustomerId == kh.CustomerId && pt.ReceiptsDate < tuNgay
                                              select pt.TotalMoney).Sum() ?? 0),
                             SoTienNo = (float)((from hd in DataProvider.Ins.DB.BillExport
                                                 join hdt in DataProvider.Ins.DB.BillExportDetails on hd.BillExportId equals hdt.BillExportId
                                                 join sp in DataProvider.Ins.DB.product on hdt.ProductId equals sp.ProductId
                                                 from d in DataProvider.Ins.DB.chietkhausp.Where(d => d.CustomerId == kh.CustomerId && d.ProductId == sp.ProductId).DefaultIfEmpty()
                                                 where hd.CustomerId == kh.CustomerId && hd.BillExportDate >= tuNgay && hd.BillExportDate <= denNgay
                                                 select hdt.Quantity * sp.ProductPrice * (1 - (d != null ? d.chietkhau : 0) / 100) * (1 - (double)hd.BillPayPercent / 100)).Sum() ?? 0),
                             SoThanhToan = (double)((from pt in DataProvider.Ins.DB.Receipts
                                                     where pt.CustomerId == kh.CustomerId && pt.ReceiptsDate >= tuNgay && pt.ReceiptsDate <= denNgay
                                                     select pt.TotalMoney).Sum() ?? 0)
                         }).ToList();


            var result = query.ToList().Select(r => new CongNoReport
            {
                TenKhachHang = r.TenKhachHang,
                SoDuDau = r.SoDuDau,
                SoTienNo = r.SoTienNo,
                SoThanhToan = r.SoThanhToan,
                SoDuCuoi=r.SoDuDau+r.SoTienNo-r.SoThanhToan
            }).ToList();

            return result;
        }

    }
}

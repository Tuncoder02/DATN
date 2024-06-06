using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CongnokhachhangDAL
    {

        private static CongnokhachhangDAL instance;
        public static CongnokhachhangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CongnokhachhangDAL();
                return instance;
            }
        }
        public class CongNoKhachHang
        {
            public DateTime NgayPhatSinh { get; set; }
            public int SoChungTu { get; set; }
            public double? PhatSinhNo { get; set; }
            public double? PhatSinhCo { get; set; }
        }
        public List<CongNoKhachHang> getCongnokhachhang(int id,DateTime tuNgay,DateTime denNgay)
        {
            var phatSinhNo = from hdbh in DataProvider.Ins.DB.BillExport
                             join hdbhct in DataProvider.Ins.DB.BillExportDetails on hdbh.BillExportId equals hdbhct.BillExportId
                             join sp in DataProvider.Ins.DB.product on hdbhct.ProductId equals sp.ProductId
                             join ck in DataProvider.Ins.DB.chietkhausp on new { hdbh.CustomerId, hdbhct.ProductId } equals new { ck.CustomerId, ck.ProductId } into cks
                             from ck in cks.DefaultIfEmpty()
                             where hdbh.CustomerId == id
                                   && hdbh.BillExportDate >= tuNgay
                                   && hdbh.BillExportDate <= denNgay &&
                                   (hdbh.BillPayPercent == 0 || hdbh.BillPayPercent == 50)
                             group new { hdbh, hdbhct, sp, ck } by new { hdbh.BillExportId, hdbh.BillExportDate } into g
                             select new CongNoKhachHang
                             {
                                 NgayPhatSinh = g.Key.BillExportDate,
                                 SoChungTu = g.Key.BillExportId,
                                 PhatSinhNo = (double)g.Sum(x => x.hdbhct.Quantity * x.sp.ProductPrice * (1 - (x.ck != null ? x.ck.chietkhau : 0) / 100) * (1 - (double)x.hdbh.BillPayPercent / 100)),
                                 PhatSinhCo = (double?)null
                             };

            var phatSinhCo = from pt in DataProvider.Ins.DB.Receipts
                             where pt.CustomerId == id
                                   && pt.ReceiptsDate >= tuNgay
                                   && pt.ReceiptsDate <= denNgay
                             select new CongNoKhachHang
                             {
                                 NgayPhatSinh = (DateTime)pt.ReceiptsDate,
                                 SoChungTu = pt.ReceiptsId,
                                 PhatSinhNo = (double?)null,
                                 PhatSinhCo = (double)pt.TotalMoney
                             };

            var ketQua = phatSinhNo
                .Union(phatSinhCo)
                .OrderBy(x => x.NgayPhatSinh)
                .ThenBy(x => x.SoChungTu)
                .ToList();
            return ketQua;
        }

        public double sodudauky(int id,DateTime tuNgay,DateTime denNgay)
        {
            var soDuDauKyNo = (from hdbh in DataProvider.Ins.DB.BillExport
                               join hdbhct in DataProvider.Ins.DB.BillExportDetails on hdbh.BillExportId equals hdbhct.BillExportId
                               join sp in DataProvider.Ins.DB.product on hdbhct.ProductId equals sp.ProductId
                               join ck in DataProvider.Ins.DB.chietkhausp on new { hdbh.CustomerId, hdbhct.ProductId } equals new { ck.CustomerId, ck.ProductId } into cks
                               from ck in cks.DefaultIfEmpty()
                               where hdbh.CustomerId == id
                                     && hdbh.BillExportDate < tuNgay
                               select hdbhct.Quantity * sp.ProductPrice * (1 - (ck != null ? ck.chietkhau : 0) / 100) * (1 - (double)hdbh.BillPayPercent / 100))
                  .Sum()?? 0;

            var soDuDauKyCo = (from pt in DataProvider.Ins.DB.Receipts
                               where pt.CustomerId == id
                                     && pt.ReceiptsDate < tuNgay
                               select pt.TotalMoney)
                              .Sum()?? 0;

            double soDuDauKy = (double)(soDuDauKyNo - soDuDauKyCo);
            return soDuDauKy;

        }
    }
}


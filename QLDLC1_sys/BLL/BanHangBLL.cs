using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DAL.BanHangDAL;

namespace BLL
{
    public class BanHangBLL
    {
        private static BanHangBLL instance;
        public static BanHangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanHangBLL();
                return instance;
            }
        }

        public void loadCustomer(ComboBox cb1,ComboBox cb2,ComboBox cb3)
        {
            List<customer> result = KhachHangDAL.Instance.GetCustomer1();
            cb1.DataSource= result;
            cb1.DisplayMember = "CustomerFullName";
            cb2.DataSource= result;
            cb2.DisplayMember = "CustomerPhoneNumber";
            cb3.DataSource= result;
            cb3.DisplayMember = "CustomerEmail";
        }

        public BillExport taoHoaDon(int idcus)
        {
            return BanHangDAL.Instance.taoHoadon(idcus);
        }

        public bool huyHoaDon(int id)
        {
            return BanHangDAL.Instance.huyBill(id);
        }

        public void getBillInfo(DataGridView data, int id)
        {
            List<BillExportDetails> result = BanHangDAL.Instance.getBillInfo(id).ToList();
            var result2 = from c in result select new { IdBill = c.BillExportDetailsId, IdProduct = c.ProductId, TenSanPham = c.product.ProductName, SoLuong = c.Quantity, Giaban=c.product.ProductPrice, ThanhTien = c.product.ProductPrice * c.Quantity };
            data.DataSource = result2.ToList();
        }

        public void getBillInfonew(DataGridView data, int id)
        {
            List<BillDetailWithDiscount> result = BanHangDAL.Instance.GetBillDetailsWithDiscounts().Where(x=>x.BillId==id).ToList();
            var result2 = from c in result select new { IdBill = c.BillDetailId, IdProduct = c.ProductId, TenSanPham = c.ProductName, SoLuong = c.Quantity, Giaban = c.Price,Chietkhau=c.DiscountAmount, ThanhTien =( c.Price * c.Quantity)*(100-c.DiscountAmount)/100 };
            data.DataSource = result2.ToList();
        }

        public void addBillInfo(int idBill, int Product, int soluong)
        {
            int kt = 0;
            List<BillExportDetails> result = BanHangDAL.Instance.getBillInfo(idBill).ToList();
            foreach (var c in result)
                if ((c.ProductId == Product))
                {
                    addBillInfo2(c.BillExportDetailsId, soluong);
                    kt = 1;

                    break;
                }
            if (kt == 0)
                addBillInfo1(idBill, Product, soluong);

        }
        public bool addBillInfo1(int idBill, int idProduct, int soluong)
        {

            return BanHangDAL.Instance.addBillInfo1(idBill, idProduct, soluong);
        }
        public bool addBillInfo2(int idBill, int soluong)
        {

            return BanHangDAL.Instance.addBillInfo2(idBill, soluong);
        }

        public bool deleteBillInfo(int id)
        {
            return BanHangDAL.Instance.deleteBill(id);
        }

        public bool updateProduct(int id,  int soluong)
        {
            return BanHangDAL.Instance.updateProduct(id, soluong);
        }
        public bool luuBill(int idBill,int idKH,int pay)
        {
            return BanHangDAL.Instance.luuBill(idBill,idKH,pay);
        }


        public void loadBillExport(DataGridView data)
        {
            List<BillExport> result = BanHangDAL.Instance.getBillExport();
            var result2 = from c in result select new { IdBill = c.BillExportId,Customer=c.CustomerId,PayPercent=c.BillPayPercent, Ngayban = c.BillExportDate };
            data.DataSource = result2.ToList();
        }

        public void deleteBillTo(int idBill)
        {
            List<BillExportDetails> result = BanHangDAL.Instance.getBillInfo(idBill).ToList();
            foreach (var c in result)
            {
                BanHangDAL.Instance.deleteBill(c.BillExportDetailsId);
            }

            BanHangDAL.Instance.deleteBillTo(idBill);
        }

        public bool updateIdcus(int idbill, int idcus)
        {
            return BanHangDAL.Instance.updateIdcus(idbill,idcus);
        }
    }
}

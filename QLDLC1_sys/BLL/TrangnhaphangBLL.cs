using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class TrangnhaphangBLL
    {
        private static TrangnhaphangBLL instance;
        public static TrangnhaphangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TrangnhaphangBLL();
                return instance;
            }
        }

        public BillImport taoHoaDon()
        {
            return TrangnhaphangDAL.Instance.taoHoadon();
        }

        public void huyHoaDon(int id)
        {
            List<BillImportDetails> result = TrangnhaphangDAL.Instance.getBillInfo(id).ToList();
            foreach (var c in result)
            {
                TrangnhaphangDAL.Instance.deleteBill(c.BillImportDetailsId);
            }

            TrangnhaphangDAL.Instance.huyBill(id);
        }

        public void loadIdSanPham(ComboBox cb)
        {
            List<product> result = KhoHangDAL.Instance.GetProducts();
            cb.DataSource = result.ToList();
 
        }
        
        public void getBillInfo(DataGridView data,int id)
        {
            List<BillImportDetails> result= TrangnhaphangDAL.Instance.getBillInfo(id).ToList();
            var result2 = from c in result select new { IdBill = c.BillImportDetailsId, IdProduct = c.ProductId, TenSanPham = c.product.ProductName, SoLuong=c.Quantity,Gianhap=c.Price,ThanhTien=c.Price*c.Quantity  };
            data.DataSource = result2.ToList();
        }
        public void addBillInfo(int idBill,int Product,int soluong,float gianhap)
        {
            int kt = 0;
            List<BillImportDetails> result = TrangnhaphangDAL.Instance.getBillInfo(idBill).ToList();
            foreach (var c in result)
                if ((c.ProductId == Product) && (c.Price == gianhap))
                {
                    addBillInfo2(c.BillImportDetailsId, soluong);
                                        kt = 1;

                    break;
                }
          if(kt==0)
                addBillInfo1(idBill,Product,soluong,gianhap);  

        }
        public bool addBillInfo1(int idBill, int idProduct, int soluong, float gianhap)
        {
            
            return TrangnhaphangDAL.Instance.addBillInfo1(idBill,idProduct,soluong,gianhap);
        }
        public bool addBillInfo2(int idBill, int soluong)
        {

            return TrangnhaphangDAL.Instance.addBillInfo2(idBill, soluong);
        }

        public bool deleteBillInfo(int id)
        {
            return TrangnhaphangDAL.Instance.deleteBill(id);
        }

        public bool updateProduct(int id,  int soluong, float gianhap)
        {
            return TrangnhaphangDAL.Instance.updateProduct(id, soluong, gianhap);
        }
        public bool luuBill(int idBill)
        {
            return TrangnhaphangDAL.Instance.luuBill(idBill);
        }
    }
}

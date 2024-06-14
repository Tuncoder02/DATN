using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class PhieuchiBLL
    {
        private static PhieuchiBLL instance;
        public static PhieuchiBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuchiBLL();
                return instance;
            }
        }
        public void getPayment(DataGridView data)
        {
            List<Payment> result = PhieuchiDAL.Instance.GetPayments().ToList();
            var result2 = from c in result select new { Idphieuchi = c.PaymentId, Idnhasx = c.NhaSXId, Tenkhachhang = c.NhaSX.NhaSXName, Sotien = c.TotalMoney, Noidung = c.Content, Ngaythu = c.PaymentDate };
            data.DataSource = result2.ToList();
        }
        public bool addPayment(int id, float sotien, string noidung, DateTime ngaythu)
        {
            return PhieuchiDAL.Instance.addPayment(id, sotien, noidung, ngaythu);
        }
        public bool removePayment(int id)
        {

            return PhieuchiDAL.Instance.removePayment(id);

        }
        public bool editPayment(int id, int nhasx, float sotien, string noidung, DateTime ngaythu)
        {

            return PhieuchiDAL.Instance.editPayment(id, nhasx, sotien, noidung, ngaythu);
        }
        public void getPaymentBySDT(DataGridView data, string sdt)
        {
            List<Payment> result = PhieuchiDAL.Instance.getPaymentBySDT(sdt).ToList();
            var result2 = from c in result select new { Idphieuchi = c.PaymentId, Idnhasx = c.NhaSXId, Tenkhachhang = c.NhaSX.NhaSXName, Sotien = c.TotalMoney, Noidung = c.Content, Ngaythu = c.PaymentDate };
            data.DataSource = result2.ToList();
        }


    }
}

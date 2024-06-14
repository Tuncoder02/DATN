using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuchiDAL
    {

        private static PhieuchiDAL instance;
        public static PhieuchiDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuchiDAL();
                return instance;
            }
        }
        public List<Payment> GetPayments()
        {
            List<Payment> products = new List<Payment>();
            products = DataProvider.Ins.DB.Payment.ToList();
            return products;
        }
        public bool addPayment(int id, float sotien, string noidung, DateTime ngaythu)
        {
            Payment pm = new Payment();
            pm.NhaSXId = id;
            pm.TotalMoney = sotien;
            pm.Content = noidung;
            pm.PaymentDate = ngaythu;
            DataProvider.Ins.DB.Payment.Add(pm);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
        public bool removePayment(int id)
        {
            Payment pm = DataProvider.Ins.DB.Payment.Find(id);
            if (pm != null)
            {
                DataProvider.Ins.DB.Payment.Remove(pm);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;

        }
        public bool editPayment(int id, int nhasxid, float sotien, string noidung, DateTime ngaythu)
        {
            Payment pm = DataProvider.Ins.DB.Payment.Find(id);
            if (pm != null)
            {
                pm.NhaSXId = nhasxid;
                pm.TotalMoney = sotien;
                pm.Content = noidung;
                pm.PaymentDate = ngaythu;

                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Payment> getPaymentBySDT(string sdt)
        {
            List<Payment> products = new List<Payment>();
            products = DataProvider.Ins.DB.Payment.Where(x => x.NhaSX.NhaSXSDT == sdt).ToList();
            return products;
        }

    }
}

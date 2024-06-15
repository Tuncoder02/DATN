using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NaptienDAL
    {

        private static NaptienDAL instance;
        public static NaptienDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NaptienDAL();
                return instance;
            }
        }
        public List<Recharge> getNap()
        {
            List<Recharge> result = DataProvider.Ins.DB.Recharge.ToList();
            return result;
        }
        public bool addNap(float tien,string content,DateTime date)
        {
            Recharge rc=new Recharge();
            rc.Content = content;
            rc.TotalMoney = tien;
            rc.RechargeDate = date;
            DataProvider.Ins.DB.Recharge.Add(rc);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
        public bool removeNap(int id)
        {
            Recharge rc = DataProvider.Ins.DB.Recharge.Find(id);
            if(rc==null) return false;
            DataProvider.Ins.DB.Recharge.Remove(rc);
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool editNap(int id,float tien,string content,DateTime date)
        {
            Recharge rc = DataProvider.Ins.DB.Recharge.Find(id);
            if (rc == null) return false;
            rc.Content = content;
            rc.TotalMoney = tien;
            rc.RechargeDate=date;
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }
        public float sodu()
        {
            float thanhtoannhap = (float)DataProvider.Ins.DB.BillImport.Sum(c => c.BillPay);
            float thanhtoanxuat=(float)DataProvider.Ins.DB.BillExport.Sum((c) => c.BillPay);
            float thu = (float)DataProvider.Ins.DB.Receipts.Sum(c => c.TotalMoney);
            float chi=(float)DataProvider.Ins.DB.Payment.Sum(c => c.TotalMoney);
            float thuong=(float)DataProvider.Ins.DB.Bonus.Sum(c => c.TotalMoney);
            float nap=(float)DataProvider.Ins.DB.Recharge.Sum((c) => c.TotalMoney);
            return thanhtoanxuat + thu + nap - chi - thanhtoannhap - thuong;

        }
    }
}

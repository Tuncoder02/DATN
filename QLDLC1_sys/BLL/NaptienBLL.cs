using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class NaptienBLL
    {

        private static NaptienBLL instance;
        public static NaptienBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NaptienBLL();
                return instance;
            }
        }
        public void getNap(DataGridView data)
        {
            List<Recharge> result = NaptienDAL.Instance.getNap();
            data.DataSource = result.ToList();
        }
        public bool addNap(float tien, string content, DateTime date)
        {
          
            return NaptienDAL.Instance.addNap(tien,content,date);
        }
        public bool removeNap(int id)
        {
           
            return NaptienDAL.Instance.removeNap(id);
        }

        public bool editNap(int id, float tien, string content, DateTime date)
        {
            
            return NaptienDAL.Instance.editNap(id,tien,content,date);
        }
        public float sodu()
        {
            
            return NaptienDAL.Instance.sodu();

        }
    }
}

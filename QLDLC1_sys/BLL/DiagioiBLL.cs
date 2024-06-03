using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class DiagioiBLL
    {
        private static DiagioiBLL instance;
        public static DiagioiBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiagioiBLL();
                return instance;
            }
        }
        public void loadProvinces(ComboBox cb)
        {
            
            List<provinces> result = DiagioiDAL.Instance.GetProvinces();
            cb.DataSource = result.ToList();
            cb.DisplayMember = "full_name";
            
        }
        public void loadDistricts(ComboBox cb1,ComboBox cb2) 
        {
            List<districts> huyen = new List<districts>();
            
            provinces nsp = cb1.SelectedItem as provinces;
            if (nsp != null)
            {
                foreach (districts a in DiagioiDAL.Instance.GetDistricts().Where(x => x.province_code == nsp.code))
                {
                    cb2.Items.Add(a);
                }
                cb2.DisplayMember = "full_name";
                cb2.SelectedItem = null;
            }

         }

        public void loadWards(ComboBox cb1, ComboBox cb2)
        {
            List<wards> xa = new List<wards>();

            districts nsp = cb1.SelectedItem as districts;
            if (nsp != null)
            {
                foreach (wards a in DiagioiDAL.Instance.GetWards().Where(x => x.district_code == nsp.code))
                {
                    cb2.Items.Add(a);
                }
                cb2.DisplayMember = "full_name";
                cb2.SelectedItem = null;
            }

        }
    }
   


}

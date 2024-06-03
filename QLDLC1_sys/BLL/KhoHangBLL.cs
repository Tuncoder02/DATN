using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace BLL
{
    public class KhoHangBLL
    {
        private static KhoHangBLL instance;
        public static KhoHangBLL Instance
        {
             get
            {
                if(instance == null)   
                    instance = new KhoHangBLL();
                return instance;
            }
        }
        public void showSanpham(DataGridView data)
        {
            List<product> result = KhoHangDAL.Instance.GetProducts();
            var result2 = from c in result select new { IdSanPham = c.ProductId,NhomSanPham =c.productgroup.ProductGroupName,TenSanPham=c.ProductName,GiaSanPham=c.ProductPrice, SoLuong=c.ProductQuantity,Mota=c.ProductInfo, linkanh = c.ProductImageLink };
            //BindingList<product> bindingList = new BindingList<product>(result2);

            data.DataSource = result2.ToList();   
        }
        public void loadProductGroup(ComboBox cb)
        {
            List<productgroup> result = NhomSanPhamDAL.Instance.GetProductGroup();
            cb.DataSource=result.ToList();
            cb.DisplayMember = "ProductGroupName";
            cb.SelectedItem = null;
        }
    
        public void filterProduct(ComboBox cb,DataGridView dtgv)
        {
            productgroup nsp = cb.SelectedItem as productgroup;
            List<product> result = new List<product>();
            if (nsp != null)
            {
                foreach (product a in KhoHangDAL.Instance.GetProducts().Where(x => x.ProductGroupName == nsp.ProductGroupId))
                {
                    result.Add(a);

                }

            }
            var result2 = from c in result select new { IdSanPham = c.ProductId, NhomSanPham = c.productgroup.ProductGroupName, TenSanPham = c.ProductName, GiaSanPham = c.ProductPrice, SoLuong = c.ProductQuantity,Mota=c.ProductInfo, linkanh = c.ProductImageLink };

            dtgv.DataSource=result2.ToList();
        }
        public void sortProductByNameAscending(DataGridView data)
        {
            List<product> result = KhoHangDAL.Instance.GetProducts();
            var result2 = from c in result select new { IdSanPham = c.ProductId, NhomSanPham = c.productgroup.ProductGroupName, TenSanPham = c.ProductName, GiaSanPham = c.ProductPrice, SoLuong = c.ProductQuantity, Mota = c.ProductInfo,linkanh=c.ProductImageLink };

            data.DataSource = result2.OrderBy(x=>x.TenSanPham).ToList();
        }
        public void sortProductByPriceDescending(DataGridView data)
        {
            List<product> result = KhoHangDAL.Instance.GetProducts();
            var result2 = from c in result select new { IdSanPham = c.ProductId, NhomSanPham = c.productgroup.ProductGroupName, TenSanPham = c.ProductName, GiaSanPham = c.ProductPrice, SoLuong = c.ProductQuantity, Mota = c.ProductInfo, linkanh = c.ProductImageLink };

            data.DataSource = result2.OrderByDescending(x => x.GiaSanPham).ToList();
        }
        public void sortProductByPriceAscending(DataGridView data)
        {
            List<product> result = KhoHangDAL.Instance.GetProducts();
            var result2 = from c in result select new { IdSanPham = c.ProductId, NhomSanPham = c.productgroup.ProductGroupName, TenSanPham = c.ProductName, GiaSanPham = c.ProductPrice, SoLuong = c.ProductQuantity, Mota = c.ProductInfo, linkanh = c.ProductImageLink };

            data.DataSource = result2.OrderBy(x => x.GiaSanPham).ToList();
        }
        public void sortProductByNameDescending(DataGridView data)
        {
            List<product> result = KhoHangDAL.Instance.GetProducts();
            var result2 = from c in result select new { IdSanPham = c.ProductId, NhomSanPham = c.productgroup.ProductGroupName, TenSanPham = c.ProductName, GiaSanPham = c.ProductPrice, SoLuong = c.ProductQuantity, Mota = c.ProductInfo, linkanh = c.ProductImageLink };

            data.DataSource = result2.OrderByDescending(x => x.TenSanPham).ToList();
        }

        public bool deleteProduct(int id)
        {
            return KhoHangDAL.Instance.deleteProduct(id);
        }

        public bool updateProduct(int id,string productname, float productprice,int productquantity,string productinfo,string img)
        {
            return KhoHangDAL.Instance.updateProduct(id, productname, productprice, productquantity, productinfo,img);
        }

        public void showImageToPictureBox(string imageName, PictureBox box)
        {
            string imagePath =imageName;
            if (File.Exists(imagePath))
            {
                box.Image = Image.FromFile(imagePath);
                box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                box.Image = Image.FromFile("..\\..\\image\\notfound.png");
                box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}

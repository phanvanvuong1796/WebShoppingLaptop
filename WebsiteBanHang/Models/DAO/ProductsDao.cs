using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;
using PagedList;

namespace WebsiteBanHang.Models.DAO
{
    public class ProductsDao
    {
        ShopLapModel model;
        ShopLapModel db = new ShopLapModel();
        public ProductsDao()
        {
            model = new ShopLapModel();
        }

        public List<List<Product>> GetFeaturedProducts()
        {
            var rsFeatureProducts = (from s in model.Products
                                     orderby s.soluong descending
                                     select s).Take(16);
            List<List<Product>> listProduct = new List<List<Product>>();
            List<Product> list = new List<Product>();
            int i = 0;
            foreach(var product in rsFeatureProducts)
            {

                list.Add(product);
                i++;
                if(i==4 || i==8 || i==12 || i == 16)
                {
                    listProduct.Add(list);
                    list = new List<Product>();
                }
            }
            return listProduct;
        }

        public IQueryable<Product> GetLastestProducts()
        {
            var rsLastestProducts = (from s in model.Products
                                     orderby s.soluong descending
                                     select s).Take(6);
            return rsLastestProducts;
        }

        public IQueryable<Product> GetProducts(string type)
        {
            //var context = new DatabaseContext();
            //var gettype = new SqlParameter("@type", type);
            //var getid = new SqlParameter("@sotrang", i);
            //var rsProduct = context.Database.SqlQuery<Product>(" exec SP_PhanTrang @type, @sotrang", type, i).ToList();

            var rsProduct = from s in model.Products
                            where s.producttype == type
                            where s.soluong > 0
                            orderby s.ma descending
                            select s;
            //rsProduct = rsProduct.ToPagedList.ToPagedList(pageNumber, pageSize);
            return rsProduct;
        }

        public List<Product> SearchProduct(string key)
        {
            string search = "";
            try
            {
                double x = double.Parse(key);
                search = "select * from Product where dongia <= "+key +"and soluong >0";
            }
            catch
            {
                search = "select * from Product where tensanpham like N'%" + key + "%' or hangsanxuat like N'%" + key + "%' or mota like N'%" + key + "%' and soluong >0";
            }
            //string search = "select * from Product where tensanpham like N'%" + key + "%'";
            var rs = db.Products.SqlQuery(search).ToList();
            return rs;
        }

        public Product GetProductDetail(string ma)
        {
            Product rs = model.Products.Find(ma);
            return rs;
        }

        public IQueryable<Product> GetAllProduct()
        {
            var rsPro = (from s in model.Products
                         where s.soluong > 0
                         select s);
            return rsPro;
        }

        public bool AddProduct(Product product)
        {
            try
            {
                model.Products.Add(product);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool EditProduct(Product product)
        {
            Product pro = model.Products.Find(product.ma);
            ProductDetail proDetail = model.ProductDetails.Find(product.ma);
            try
            {
                pro.tensanpham = product.tensanpham;
                pro.dongia = product.dongia;
                pro.hangsanxuat = product.hangsanxuat;
                pro.soluong = product.soluong;
                pro.producttype = product.producttype;
                pro.imglink = product.imglink;
                pro.mota = product.mota;
                proDetail.ram = product.ProductDetail.ram;
                proDetail.diacung = product.ProductDetail.diacung;
                proDetail.vga = product.ProductDetail.vga;
                proDetail.manhinh = product.ProductDetail.manhinh;
                proDetail.vixuly = product.ProductDetail.vixuly;
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteProduct(string ma)
        {
            Product pro = model.Products.Find(ma);
            ProductDetail proDetail = model.ProductDetails.Find(ma);
            if (pro != null)
            {
                model.Products.Remove(pro);
                model.ProductDetails.Remove(proDetail);
                model.SaveChanges();
                return true;
            }else
            {
                return false;
            }
        }

        public Product FindProduct(string ma)
        {
            Product pro = model.Products.Find(ma);
            ProductDetail proDetail = model.ProductDetails.Find(ma);
            return pro;
        }
    
    }
}
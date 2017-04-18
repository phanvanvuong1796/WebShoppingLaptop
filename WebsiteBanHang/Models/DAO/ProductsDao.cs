using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class ProductsDao
    {
        ShopLaptopModel model;
        public ProductsDao()
        {
            model = new ShopLaptopModel();
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
            var rsProduct = (from s in model.Products
                             where s.producttype == type
                             select s);
            return rsProduct;
        }

        public Product GetProductDetail(string ma)
        {
            Product rs = model.Products.Find(ma);
            return rs;
        }
    }
}
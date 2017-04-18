using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class ProductsDao
    {
        ShopLapModel model;
        public ProductsDao()
        {
            model = new ShopLapModel();
        }

        public IQueryable<Product> GetFeaturedProducts()
        {
            var rsFeatureProducts = (from s in model.Products
                                     orderby s.)
        }
    }
}
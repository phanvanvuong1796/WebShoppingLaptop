using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models
{
    public class IndexData
    {
        public IQueryable<Category> listCategory { get; set; }
        public IQueryable<Product> lastestProducts { get; set; }
        public List<List<Product>> featuredProducts { get; set; }
        public IQueryable<Product> listProductsType { get; set; }
        public Product productsDetail { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class IndexData
    {
        public List<Category> listCategory { get; set; }
        public List<Product> lastestProducts { get; set; }
        public List<List<Product>> featuredProducts { get; set; }
        public List<Product> listProductsType { get; set; }
        public Product productsDetail { get; set; }
    }
}
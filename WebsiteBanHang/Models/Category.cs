using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class Category
    {
        public string categoryName { get; set; }
        public int categoryQuantity { get; set; }
        public List<SubCategory> listSubCate { get; set; }
    }

    public class SubCategory
    {
        public string subCateName { get; set; }
        public int subCateQuantity { get; set; }
        public string subCateType { get; set; }
    }
}
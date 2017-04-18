using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class CategoryDao
    {
        ShopLapModel shopLapModel;
        public CategoryDao()
        {
            shopLapModel = new ShopLapModel();
        }

        public List<Category> getCategory()
        {
            return null;
        }
    }
}
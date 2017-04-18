using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class CategoryDao
    {
        ShopLaptopModel shopLapModel;
        public CategoryDao()
        {
            shopLapModel = new ShopLaptopModel();
        }

        public IQueryable<Category> GetCategory()
        {
            //List<Category> listCategory = new List<Category>();
            //ICollection<SubCategory> subList = new List<SubCategory>();
            //var rsCate = (from s in shopLapModel.Categories select s);
            //foreach(var category in rsCate)
            //{
            //    var rsSubCate = (from rs in shopLapModel.SubCategories
            //                     where rs.danhmucma == category.ma
            //                     select rs);
            //    subList = new List<SubCategory>();
            //    foreach(var subCate in rsSubCate)
            //    {
            //        subList.Add(subCate);
            //    }
            //    listCategory.Add(category, subList);
            //}
            //return listCategory;
            var rsCate = (from s in shopLapModel.Categories select s);
            return rsCate;
        }
    }
}
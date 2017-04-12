using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IndexData data = new IndexData {
                listCategory = getCategory(),
                featuredProducts = getFeaturedProducts(),
                lastestProducts = getLastestProducts()
            };
            return View(data);
        }

        public ActionResult Products(string type)
        {
            List<Product> list = getProducts(type);
            IndexData data = new IndexData
            {
                listCategory = getCategory(),
                listProductsType = list
            };
            return View(data);
        }

        public ActionResult ProductsDetail(string type, int id)
        {
            List<Product> list;
            if ("LASTPROD".Equals(type))
            {
                list = getLastestProducts();
            }else if ("FEATPROD".Equals(type)){
                list = new List<Product>();
                List<List<Product >> listFeat = getFeaturedProducts();
                foreach(var lis in listFeat)
                {
                    foreach(var prod in lis)
                    {
                        list.Add(prod);
                    }
                }
            }else
            {
                list = getProducts(type);
            }
            Product product =null;
            foreach(var pro in list)
            {
                if (id == pro.Id)
                {
                    product = pro;
                    break;
                }
            }
            IndexData data = new IndexData
            {
                listCategory = getCategory(),
                productsDetail = product
                
            };
            return View(data);
        }

        public List<Product> getProducts(string type)
        {
            List<Product> list = new List<Product>();
            Product product;
            for(int i=0; i<6; i++)
            {
                product = new Product();
                product.Id = i;
                product.Name = "Laptop " + type + " "+(i + 1);
                product.Price = "10.000.000";
                product.Details = "Intel Core i5/4GB/500GB/7200rpm";
                product.UriImage = "/Content/themes/images/products/" + (i + 1) + ".jpg";
                product.Type = type;
                list.Add(product);
            }
            return list;
        }

        public List<Product> getLastestProducts()
        {
            List<Product> list = new List<Product>();
            Product product;
            for(int i=0; i<6; i++)
            {
                product = new Product();
                product.Id = i;
                product.Name = "Laptop " + (i + 1);
                product.Price = "20.000.000";
                product.Details = "Intel Core i5/4GB/500GB/7200rpm";
                product.UriImage = "/Content/themes/images/products/"+(i+1)+".jpg";
                product.Type = "LASTPROD";
                list.Add(product);
            }
            return list;
        }

        public List<List<Product>> getFeaturedProducts()
        {
            List<Product> list = new List<Product>();
            List<List<Product>> listFeatured = new List<List<Product>>();
            Product product;
            for (int i = 0; i < 16; i++)
            {
                product = new Product();
                product.Id = i;
                product.Name = "Laptop " + (i + 1);
                product.Price = "20.000.000";
                product.Details = "Intel Core i5/4GB/500GB/7200rpm";
                product.UriImage = "/Content/themes/images/products/" + (i + 1) + ".jpg";
                product.Type = "FEATPROD";
                list.Add(product);
                if(i==3 || i==7 || i==11 || i == 15)
                {
                    listFeatured.Add(list);
                    list = new List<Product>();
                }
            }
            return listFeatured;
        }
        public List<Category> getCategory()
        {
            List<Category> list = new List<Category>();
            List<SubCategory> subList = new List<SubCategory>();
            subList.Add(new SubCategory { subCateName = "Laptop Dell", subCateQuantity = 30, subCateType="DELL" });
            subList.Add(new SubCategory { subCateName = "Laptop HP", subCateQuantity = 30, subCateType="HP" });
            subList.Add(new SubCategory { subCateName = "Laptop Lenovo", subCateQuantity = 20, subCateType="LENOVO" });
            subList.Add(new SubCategory { subCateName = "Laptop Asus", subCateQuantity = 20, subCateType="ASUS" });
            list.Add(new Category { categoryName="LAPTOP PHỔ THÔNG", categoryQuantity=100, listSubCate=subList});
            subList = new List<SubCategory>();
            subList.Add(new SubCategory { subCateName = "Laptop Dell workstation", subCateQuantity = 20, subCateType="DELLWORK" });
            subList.Add(new SubCategory { subCateName = "Laptop HP workstation", subCateQuantity = 12, subCateType="HPWORK" });
            subList.Add(new SubCategory { subCateName = "Laptop ThinkPad workstation", subCateQuantity = 20, subCateType="THINKWORK" });
            subList.Add(new SubCategory { subCateName = "Laptop MSI workstation", subCateQuantity = 20, subCateType="MSIWORK" });
            list.Add(new Category { categoryName = "LAPTOP WORKSTATION", categoryQuantity = 50, listSubCate = subList });
            subList = new List<SubCategory>();
            subList.Add(new SubCategory { subCateName = "Laptop MSI Gaming", subCateQuantity = 20, subCateType="MSIGAME" });
            subList.Add(new SubCategory { subCateName = "Laptop Dell Alienware", subCateQuantity = 20, subCateType = "DELLGAME" });
            subList.Add(new SubCategory { subCateName = "Laptop Asus ROG", subCateQuantity = 20, subCateType = "ASUSGAME" });
            subList.Add(new SubCategory { subCateName = "Laptop HP Gaming", subCateQuantity = 20, subCateType="HPGAME" });
            subList.Add(new SubCategory { subCateName = "Laptop Lenovo Gaming", subCateQuantity = 20, subCateType="LENOVOGAME" });
            list.Add(new Category { categoryName = "LAPTOP GAMING", categoryQuantity = 150, listSubCate = subList });
            subList = new List<SubCategory>();
            subList.Add(new SubCategory { subCateName = "Laptop HP Elitebook", subCateQuantity = 20, subCateType="HPBUSI" });
            subList.Add(new SubCategory { subCateName = "Laptop Dell Latitude", subCateQuantity = 20, subCateType="DELLBUSI" });
            subList.Add(new SubCategory { subCateName = "Laptop Lenovo ThinkPad", subCateQuantity = 20, subCateType="LENOVOBUSI" });
            list.Add(new Category { categoryName = "LAPTOP BUSINESS", categoryQuantity = 50, listSubCate = subList });
            return list;
        }
    }
}
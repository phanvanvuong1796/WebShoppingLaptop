using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;
using WebsiteBanHang.Models.Bean;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Add(string ma, int soluong)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart == null)
                Cart = new ShoppingCart();

            ProductsDao dao = new ProductsDao();
            Product pro = dao.FindProduct(ma);
            Cart.AddItem(pro, soluong);

            Session["cart"] = Cart;

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Sub(string ma, int soluong)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart == null)
                Cart = new ShoppingCart();

            ProductsDao dao = new ProductsDao();
            Product pro = dao.FindProduct(ma);
            Cart.SubItem(pro, soluong);

            Session["cart"] = Cart;

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult List()
        {
            CategoryDao categoryDao = new CategoryDao();
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            List<ItemCart> listItem = new List<ItemCart>();
            IndexData data = new IndexData();
            data.listCategory = categoryDao.GetCategory();
            if (Cart != null)
            {
                data.listItemCart = Cart.listItem;
            }
            else
            {
                data.listItemCart = listItem;
                Session["cart"] = new ShoppingCart();
            }
                
            return View(data);
        }

        public ActionResult UpdateAmount()
        {
            return View();
        }

        public ActionResult Delete(string ma)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart != null)
                Cart.Delete(ma);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Payment()
        {
            CategoryDao categoryDao = new CategoryDao();
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            List<ItemCart> listItem = new List<ItemCart>();
            IndexData data = new IndexData();
            data.listCategory = categoryDao.GetCategory();
            if (Cart != null)
            {
                data.listItemCart = Cart.listItem;
            }
            else
            {
                data.listItemCart = listItem;
                Session["cart"] = new ShoppingCart();
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string shipMobile, string shipAddress, string shipEmail)
        {
            var order = new Order();
            order.ngaytao = DateTime.Now;
            order.shipName = shipName;
            order.shipMobile = shipMobile;
            order.shipAddress = shipAddress;
            order.shipEmail = shipEmail;

            try
            {
                var ma = new OrderDao().Insert(order);
                var detailDao = new OrderDetailDao();
                CategoryDao categoryDao = new CategoryDao();
                ShoppingCart Cart = (ShoppingCart)Session["cart"];
                List<ItemCart> listItem = new List<ItemCart>();
                IndexData data = new IndexData();
                data.listCategory = categoryDao.GetCategory();

                if (Cart != null)
                {
                    data.listItemCart = Cart.listItem;
                    foreach (var item in data.listItemCart)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.masanpham = item.Product.ma;
                        orderDetail.madathang = ma;
                        orderDetail.dongia = item.Product.dongia;
                        orderDetail.soluong = item.soluong;

                        detailDao.Insert(orderDetail);
                    }
                }
                else
                {
                    data.listItemCart = listItem;
                    Session["cart"] = new ShoppingCart();
                    foreach (var item in data.listItemCart)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.masanpham = item.Product.ma;
                        orderDetail.madathang = ma;
                        orderDetail.dongia = item.Product.dongia;
                        orderDetail.soluong = item.soluong;

                        detailDao.Insert(orderDetail);
                    }
                }
               
            }
            catch
            {
                return Redirect("/loi-thanh-toan");
            }

            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
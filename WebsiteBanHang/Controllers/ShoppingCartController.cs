using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;
using WebsiteBanHang.Models.Bean;

namespace WebsiteBanHang.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Add(string ma)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart == null)
                Cart = new ShoppingCart();

            ProductsDao dao = new ProductsDao();
            Product pro = dao.FindProduct(ma);
            Cart.AddItem(pro.ma, pro.tensanpham, 1, (double)pro.dongia, pro.imglink);

            Session["cart"] = Cart;

            return Redirect(Request.UrlReferrer.ToString()); 
        }

        public ActionResult List()
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            List<ItemCart> listItem = new List<ItemCart>();
            if (Cart != null)
                listItem = Cart.listItem;
            return View(listItem);
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
    }
}
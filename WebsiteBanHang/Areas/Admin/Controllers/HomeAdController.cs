using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class HomeAdController : Controller
    {
        // GET: Admin/HomeAd
        public ActionResult Index()
        {
            if(Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public ActionResult ProductManager()
        {
            ProductsDao dao = new ProductsDao();
            IQueryable<Product> list = dao.GetAllProduct();
            return View(list);
        }
    }
}
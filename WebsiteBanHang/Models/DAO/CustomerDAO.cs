using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class CustomerDAO
    {
        ShopLapModel model;
        public CustomerDAO()
        {
            model = new ShopLapModel();
        }

        public IQueryable<Customer> listKH()
        {
            var res = (from kh in model.Customers select kh);
            return res;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class OrderDetailDao
    {
        ShopLapModel model;
        public OrderDetailDao()
        {
            model = new ShopLapModel();
        }

        public bool Insert(OrderDetail detail)
        {
            try
            {
                model.OrderDetails.Add(detail);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
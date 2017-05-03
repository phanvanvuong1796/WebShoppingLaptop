using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models.Bean
{
    public class ItemCart
    {
        public string ma { get; set; }
        public string tensanpham { get; set; }
        public int soluong { get; set; }
        public double dongia { get; set; }
        public string imglink { get; set; }

        public double GetTotal()
        {
            return soluong * dongia;
        }
    }
}
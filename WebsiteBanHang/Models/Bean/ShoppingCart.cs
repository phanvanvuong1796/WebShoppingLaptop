using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models.Bean
{
    public class ShoppingCart
    {
        public List<ItemCart> listItem = new List<ItemCart>();

        public void AddItem(string ma, string tensanpham, int soluong, double dongia, string imglink)
        {
            bool check = true;
            foreach(var itemTmp in listItem)
            {
                if(itemTmp.ma == ma)
                {
                    check = true;
                    itemTmp.soluong += soluong;
                    break;
                }
            }
            if (!check)
            {
                ItemCart item = new ItemCart();
                item.ma = ma;
                item.tensanpham = tensanpham;
                item.soluong = soluong;
                item.dongia = dongia;
                item.imglink = imglink;
                listItem.Add(item);
            }
        }

        public void AddAmount(string ma, int soluong)
        {
            foreach(var itemTmp in listItem)
            {
                if(itemTmp.ma == ma)
                {
                    itemTmp.soluong += soluong;
                    break;
                }
            }
        }

        public void Delete(string ma)
        {
            foreach(var itemTmp in listItem)
            {
                if(itemTmp.ma == ma)
                {
                    listItem.Remove(itemTmp);
                    break;
                }
            }
        }

        public double GetTotalCart()
        {
            double total = 0;
            foreach(var itemTmp in listItem)
            {
                total += itemTmp.GetTotal();
            }
            return total;
        }

        public int GetAmount()
        {
            int soluong = 0;
            foreach(var itemTmp in listItem)
            {
                soluong += itemTmp.soluong;
            }
            return soluong;
        }
    }
}
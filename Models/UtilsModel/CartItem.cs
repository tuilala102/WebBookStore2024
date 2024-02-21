using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBookStore.Models.WebBookStore;

namespace WebBookStore.Models
{
    [Serializable]
    public class CartItem
    {

        public SANPHAM product { set; get; }
        public int Quantity { set; get; }

    }
}
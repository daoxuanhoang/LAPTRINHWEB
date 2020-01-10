using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    [Serializable]
    public class Cartitem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}
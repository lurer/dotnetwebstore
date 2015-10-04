using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class ShoppingCart
    {
        public ShoppingCart() { Items = new List<Item>(); }

        public string SessionID { get; set; }

        public List<Item> Items { get; set; } 
    }
}
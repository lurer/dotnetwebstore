using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public int ItemID { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public Item Item { get; set; }
    }
}
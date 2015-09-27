using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
               
        public DateTime DateBought { get; set; }
        public Order Order { get; set; }
    }
}
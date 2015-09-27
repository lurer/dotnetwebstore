using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class Order
    {
        
        public int OrderNumber { get; set; }
        public Customer User { get; set; }
        public DateTime DateTime { get; set; }
        public List<OrderLine> Items { get; set; }

        
    }
}
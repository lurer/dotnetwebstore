using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class Order
    {
        [Key]
        [Display(Name ="Order number")]
        public int OrderNumber { get; set; }

        [Display(Name ="User ID")]
        public User User { get; set; }
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        public List<OrderLine> Items { get; set; }

        [Display(Name ="Price of order")]
        public double OrderPriceTotal { get; set; }
        
    }
}
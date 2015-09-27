using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.DbModels
{
    public class DbOrderLine
    {
        [Key]
        public int OrderLineID { get; set; }
        public int ItemID { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public DbItem Item { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.DbModels
{
    public class DbOrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderLineID { get; set; }
        
        public int Amount { get; set; }
        public double Discount { get; set; }
        public DbItem Item { get; set; }
              
    }
}
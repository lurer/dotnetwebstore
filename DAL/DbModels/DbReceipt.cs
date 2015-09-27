using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.DbModels
{
    public class DbReceipt
    {
        [Key]
        public int ReceiptID { get; set; }
        
        public DateTime DateBought { get; set; }
        public virtual DbOrder Order { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.DbModels
{
    public class DbOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }
        public virtual DbUser User { get; set; }
        public DateTime DateTime { get; set; }
        public virtual List<DbOrderLine> Items { get; set; }

        
    }
}
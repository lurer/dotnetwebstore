using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbModels
{
    public class DbOrder : IAuditedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual DbUser User { get; set; }
        public DateTime DateTime { get; set; }

        public virtual List<DbOrderLine> Items { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbModels
{
    public class DbOrderLine : IAuditedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderLineID { get; set; }
        
        public int Amount { get; set; }
        public double Discount { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual DbItem Item { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}
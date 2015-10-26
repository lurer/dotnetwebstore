using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbModels
{
    public class DbItem : IAuditedEntity
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set;}
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int InStock { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
        public string ImgPath { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }

    }
}
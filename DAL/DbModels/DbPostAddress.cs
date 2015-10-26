using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.DbModels
{
    public class DbPostAddress : IAuditedEntity
    {
        [Key]
        public string PostCode { get; set; }
        public string PostAddres { get; set; }

        public virtual List<DbUser> Users { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}
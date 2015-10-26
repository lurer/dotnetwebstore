using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbModels
{
    public class DbRole : IAuditedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleStringId { get; set; }
        public string RoleName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.DbModels
{
    public class DbUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }

        public virtual DbPostAddress PostAddress { get; set; }
        public string RoleStringId { get; set; }
        public int RoleId { get; set; }
    }
}
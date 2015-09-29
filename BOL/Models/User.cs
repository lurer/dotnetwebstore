using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class User
    {
        public int UserID { get; set; }


        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        
        [StringLength(8)]
        public string Telephone { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [Required]
        [StringLength(4)]
        public string PostCode { get; set; }

        [Required]
        public string PostAddress { get; set; }

        public string RoleId { get; set; }

    }
}
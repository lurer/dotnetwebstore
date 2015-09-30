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


        [Required(ErrorMessage = "Please enter your first name") MinLength(2)]
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter your last name"), MinLength(3)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter a valid email address"), RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password must be a minimum of 5 characters"), MinLength(5)]
        public string Password { get; set; }
        
        [StringLength(8)]
        public string Telephone { get; set; }

        [Required(ErrorMessage ="Please enter a valid address. Minimum 5 characters long"), MinLength(5)]
        public string Address { get; set; }

        [Required(ErrorMessage ="Please enter a valid post code. 4 digits long"), RegularExpression(@"^\d{4}$")]
        [Display(Name ="Post code")]
        public string PostCode { get; set; }

        [Required(ErrorMessage ="Please enter a Post address")]
        [Display(Name ="Post address")]
        public string PostAddress { get; set; }

        public string RoleStringId { get; set; }
        public int RoleId { get; set; }

    }
}
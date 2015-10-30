using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage ="Please enter a one letter representation of the role"), RegularExpression(@"^[A-Z]{1}$")]
        [Display(Name ="Role Id")]
        public string RoleStringId { get; set; }

        [MinLength(3),Required(ErrorMessage ="Please enter the name of the role, like Admin, Customer etc")]
        [Display(Name ="Role name")]
        public string RoleName { get; set; }
    }
}

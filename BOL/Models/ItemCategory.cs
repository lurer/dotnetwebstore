using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Please enter the Category name")]
        [Display(Name ="Category name")]
        public string CategoryName { get; set; }
    }
}

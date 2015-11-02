using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class Item
    { 
        public int ItemID { get; set;}

        [Required, RegularExpression(@"^[A-ZÆØÅ]{5}$", ErrorMessage = "Item code is a 5 letter compact code")]
        [Display(Name ="Item code")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage ="Please write a short description of the product"),MinLength(20)]
        [Display(Name ="Description")]
        public string ItemDesc { get; set; }

        [Required(ErrorMessage ="Please enter how many items that are in stock")]
        [Display(Name ="In stock")]
        public int InStock { get; set; }

        [Required(ErrorMessage ="Please enter the current price")]
        public double Price { get; set; }

        [Required(ErrorMessage ="Please choose a category from the list")]
        public int Category { get; set; }

        public string ImgPath { get; set; }
    }
}
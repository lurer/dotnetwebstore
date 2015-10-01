using BOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Admin.Models
{
    public class ItemViewPopulated
    {
        public int ItemID { get; set; }
 
        [Required(ErrorMessage = "Item code is a 5 letter compact code"), MinLength(5), MaxLength(5)]
        [Display(Name = "Item code")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Please write a short description of the product"), MinLength(20)]
        [Display(Name = "Description")]
        public string ItemDesc { get; set; }

        [Required(ErrorMessage = "Please enter how many items that are in stock")]
        [Display(Name = "In stock")]
        public int InStock { get; set; }

        [Required(ErrorMessage = "Please enter the current price")]
        public double Price { get; set; }

        public int SelectedCategory { get; set; }

      //  [Required(ErrorMessage = "Please choose a category from the list")]
        public SelectList Categories { get; set; }

        public string ImgPath { get; set; }
    }
}
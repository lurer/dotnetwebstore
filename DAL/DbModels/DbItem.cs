using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.DbModels
{
    public class DbItem
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
    }
}
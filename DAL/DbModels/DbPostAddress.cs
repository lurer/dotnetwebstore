using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.DbModels
{
    public class DbPostAddress
    {
        [Key]
        public string PostCode { get; set; }
        public string PostAddres { get; set; }

        public virtual List<DbUser> Users { get; set; }
    }
}
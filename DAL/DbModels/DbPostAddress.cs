using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
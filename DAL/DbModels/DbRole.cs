using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbModels
{
    public class DbRole
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}

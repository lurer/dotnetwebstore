using BOL.Models;
using DAL.DbModels;
using ObjectConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectConverters
{
    public class RoleConverter : AbstractConverter<DbRole, Role>
    {
        public override DbRole TransFromBusinessToDb(Role obj)
        {
            return new DbRole { RoleStringId = obj.RoleStringId, RoleName = obj.RoleName };
        }

        public override Role TransFromDbToBusiness(DbRole dbObj)
        {
            return new Role { RoleId = dbObj.RoleId, RoleStringId = dbObj.RoleStringId, RoleName = dbObj.RoleName };
        }
    }
}

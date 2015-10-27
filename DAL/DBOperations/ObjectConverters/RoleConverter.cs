using BOL.Models;
using DAL.DbModels;

namespace DAL.DBOperations.ObjectConverters
{
    public class RoleConverter : AbstractConverter<DbRole, Role>
    {
        public override DbRole TransFromBusinessToDb(Role obj, DbRole dbRole)
        {
            if(dbRole == null)
            {
                dbRole = new DbRole();
            }
            dbRole.RoleStringId = obj.RoleStringId;
            dbRole.RoleName = obj.RoleName;
            return dbRole;
        }

        public override Role TransFromDbToBusiness(DbRole dbObj)
        {
            return new Role { RoleId = dbObj.RoleId, RoleStringId = dbObj.RoleStringId, RoleName = dbObj.RoleName };
        }
    }
}

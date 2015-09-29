using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.DataServices
{
    public class RoleService : AbstractService<DbRole, Role>
    {
        public override void Insert(Role inObj)
        {
            DbRole dbRole = new DbRole{RoleName = inObj.RoleName};
            using (var context = new DataContext())
            {
                context.Roles.Add(dbRole);
                context.SaveChanges();
            }
        }

        public override void Update(Role obj)
        {
            DbRole dbRole = new DbRole { RoleName = obj.RoleName };
            using (var context = new DataContext())
            {
                context.Entry(dbRole).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        internal override DbRole transFromBusinessToDb(Role obj)
        {
            return new DbRole { RoleName = obj.RoleName };
        }

        internal override Role transFromDbToBusiness(DbRole dbObj)
        {
            return new Role { RoleId = dbObj.RoleId, RoleName = dbObj.RoleName };
        }
    }
}

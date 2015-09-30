using BOL.Models;
using DAL.DbModels;
using ObjectConverters;
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
            DbRole dbRole = transFromBusinessToDb(inObj);
            using (var context = new DataContext())
            {
                context.Roles.Add(dbRole);
                context.SaveChanges();
            }
        }

        public override void Update(Role obj)
        {
            DbRole dbRole = transFromBusinessToDb(obj);
            using (var context = new DataContext())
            {
                context.Entry(dbRole).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        internal override DbRole transFromBusinessToDb(Role obj)
        {
            return new RoleConverter().TransFromBusinessToDb(obj);
        }

        internal override Role transFromDbToBusiness(DbRole dbObj)
        {
            return new RoleConverter().TransFromDbToBusiness(dbObj);
        }
    }
}

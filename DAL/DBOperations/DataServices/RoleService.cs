using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations.ObjectConverters;
using System.Data.Entity;

namespace DAL.DBOperations.DataServices
{
    public class RoleService : AbstractService<DbRole, Role>
    {
        public override Role Insert(Role inObj)
        {
            DbRole dbRole = transFromBusinessToDb(inObj);
            using (var context = new DataContext())
            {
                context.Roles.Add(dbRole);
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbRole);
        }

        public override Role Update(Role obj)
        {
            DbRole dbRole = transFromBusinessToDb(obj);
            using (var context = new DataContext())
            {
                context.Entry(dbRole).State = EntityState.Modified;
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbRole);
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

using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations.ObjectConverters;
using DAL.Utilities;
using System;
using System.Data.Entity;

namespace DAL.DBOperations.DataServices
{
    public class RoleService : AbstractService<DbRole, Role>
    {
        public override Role Insert(Role inObj)
        {
            DbRole dbRole = transFromBusinessToDb(inObj, null);
            using (var context = new DataContext())
            {
                try
                {
                    context.Roles.Add(dbRole);
                    context.SaveChanges();
                }
                catch (DBUpdateException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

            }
            return transFromDbToBusiness(dbRole);
        }

        public override Role Update(Role obj)
        {
            
            using (var context = new DataContext())
            {
                DbRole dbRole = context.Roles.Find(obj.RoleId);
                dbRole = transFromBusinessToDb(obj, dbRole);
                try
                {
                    context.Entry(dbRole).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DBUpdateException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }
                return transFromDbToBusiness(dbRole);
            }
            
        }

        internal override DbRole transFromBusinessToDb(Role obj, DbRole dbObj)
        {
            return new RoleConverter().TransFromBusinessToDb(obj, dbObj);
        }

        internal override Role transFromDbToBusiness(DbRole dbObj)
        {
            return new RoleConverter().TransFromDbToBusiness(dbObj);
        }
    }
}

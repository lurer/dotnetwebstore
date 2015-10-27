
using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations.ObjectConverters;
using DAL.Utilities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL.DBOperations.DataServices
{
    public class ItemService : AbstractService<DbItem, Item>
    {
        public override Item Insert(Item inObj)
        {
            DbItem dbItem = transFromBusinessToDb(inObj, null);
            using(var context = new DataContext())
            {
                try
                {
                    context.Items.Add(dbItem);
                    context.SaveChanges();
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

            }
            return transFromDbToBusiness(dbItem);
        }

        public override Item Update(Item obj)
        {
            
            using(var context = new DataContext())
            {
                
                DbItem dbItem = context.Items.Find(obj.ItemID);
                dbItem = transFromBusinessToDb(obj, dbItem);
                try
                {
                    context.Entry(dbItem).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }
                return transFromDbToBusiness(dbItem);
            }
            
        }

        internal override DbItem transFromBusinessToDb(Item obj, DbItem dbObj)
        {
            return new ItemConverter().TransFromBusinessToDb(obj, dbObj);
        }

        internal override Item transFromDbToBusiness(DbItem dbObj)
        {
            return new ItemConverter().TransFromDbToBusiness(dbObj);
        }
    }
}

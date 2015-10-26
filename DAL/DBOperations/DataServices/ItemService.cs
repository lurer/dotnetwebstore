
using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations.ObjectConverters;
using System.Data.Entity;

namespace DAL.DBOperations.DataServices
{
    public class ItemService : AbstractService<DbItem, Item>
    {
        public override Item Insert(Item inObj)
        {
            DbItem dbItem = transFromBusinessToDb(inObj);
            using(var context = new DataContext())
            {
                context.Items.Add(dbItem);
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbItem);
        }

        public override Item Update(Item obj)
        {
            DbItem dbItem = transFromBusinessToDb(obj);
            using(var context = new DataContext())
            {
                context.Entry(dbItem).State = EntityState.Modified;
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbItem);
        }

        internal override DbItem transFromBusinessToDb(Item obj)
        {
            return new ItemConverter().TransFromBusinessToDb(obj);
        }

        internal override Item transFromDbToBusiness(DbItem dbObj)
        {
            return new ItemConverter().TransFromDbToBusiness(dbObj);
        }
    }
}

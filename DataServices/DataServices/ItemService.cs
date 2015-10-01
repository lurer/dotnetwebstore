using BOL.Models;
using DAL;
using DAL.DbModels;
using ObjectConverters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
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

using BOL.Models;
using DAL;
using DAL.DbModels;
using DataServices.Adapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Services
{
    public class ItemService : AbstractService<DbItem, Item>
    {
        public override void Insert(Item inObj)
        {
            DbItem dbItem = transFromBusinessToDb(inObj);
            using(var context = new DataContext())
            {
                context.Items.Add(dbItem);
                context.SaveChanges();
            }
        }

        public override void Update(Item obj)
        {
            DbItem dbItem = transFromBusinessToDb(obj);
            using(var context = new DataContext())
            {
                context.Entry(dbItem).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        internal override DbItem transFromBusinessToDb(Item obj)
        {
            return new ItemAdapter().TransFromBusinessToDb(obj);
        }

        internal override Item transFromDbToBusiness(DbItem dbObj)
        {
            return new ItemAdapter().TransFromDbToBusiness(dbObj);
        }
    }
}

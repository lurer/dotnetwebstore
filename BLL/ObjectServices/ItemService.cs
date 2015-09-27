using BLL.ObjectServices;
using BOL.Models;
using DAL;
using DAL.DbModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectServices
{
    public class ItemService : AbstractService<T, Item>
    {
        public override void Insert(Item inObj)
        {
            T dbItem = transFromBusinessToDb(inObj);
            using(var context = new DataContext())
            {
                context.Items.Add(dbItem);
                context.SaveChanges();
            }
        }

        public override void Update(Item obj)
        {
            T dbItem = transFromBusinessToDb(obj);
            using(var context = new DataContext())
            {
                context.Entry(dbItem).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        internal override T transFromBusinessToDb(Item obj)
        {
            T dbItem = new T()
            {
                ItemID = obj.ItemID,
                ItemNumber = obj.ItemNumber,
                ItemDesc = obj.ItemDesc,
                InStock = obj.InStock,
                Price = obj.Price
            };
            return dbItem;
        }

        internal override Item transfromDbToBusiness(T dbObj)
        {
            Item newItem = new Item()
            {
                ItemID = dbObj.ItemID,
                ItemNumber = dbObj.ItemNumber,
                ItemDesc = dbObj.ItemDesc,
                InStock = dbObj.InStock,
                Price = dbObj.Price
            };
            return newItem;
        }
    }
}

using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectConverters
{
    public class ItemAdapter : AbstractAdapter<DbItem, Item>
    {
        public override DbItem TransFromBusinessToDb(Item obj)
        {
            DbItem dbItem = new DbItem()
            {
                ItemID = obj.ItemID,
                ItemNumber = obj.ItemNumber,
                ItemDesc = obj.ItemDesc,
                InStock = obj.InStock,
                Price = obj.Price
            };
            return dbItem;
        }

        public override Item TransFromDbToBusiness(DbItem dbObj)
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

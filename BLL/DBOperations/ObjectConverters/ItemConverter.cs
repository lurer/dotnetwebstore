using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DBOperations.ObjectConverters
{
    public class ItemConverter : AbstractConverter<DbItem, Item>
    {
        public override DbItem TransFromBusinessToDb(Item obj)
        {

            DbItem dbItem = new DbItem()
            {
                ItemID = obj.ItemID,
                ItemCode = obj.ItemCode,
                ItemDesc = obj.ItemDesc,
                InStock = obj.InStock,
                Price = obj.Price,
                Category = obj.Category,
                ImgPath = obj.ImgPath
            };

            return dbItem;

        }

        public override Item TransFromDbToBusiness(DbItem dbObj)
        {

            Item newItem = new Item()
            {
                ItemID = dbObj.ItemID,
                ItemCode = dbObj.ItemCode,
                ItemDesc = dbObj.ItemDesc,
                InStock = dbObj.InStock,
                Price = dbObj.Price,
                Category = dbObj.Category,
                ImgPath = dbObj.ImgPath
            };
            return newItem;

        }
    }
}

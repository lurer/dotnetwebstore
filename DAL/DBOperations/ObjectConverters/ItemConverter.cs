using BOL.Models;
using DAL.DbModels;

namespace DAL.DBOperations.ObjectConverters
{
    public class ItemConverter : AbstractConverter<DbItem, Item>
    {
        public override DbItem TransFromBusinessToDb(Item obj, DbItem dbItem)
        {
            if(dbItem == null)
            {
                dbItem = new DbItem();
            }

            dbItem.ItemID = obj.ItemID;
            dbItem.ItemCode = obj.ItemCode;
            dbItem.ItemDesc = obj.ItemDesc;
            dbItem.InStock = obj.InStock;
            dbItem.Price = obj.Price;
            dbItem.Category = obj.Category;
            dbItem.ImgPath = obj.ImgPath;


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

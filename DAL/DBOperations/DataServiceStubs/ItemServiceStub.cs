using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBOperations.DataServiceStubs
{
    public class ItemServiceStub : IDataService<DbItem, Item>
    {
        public Boolean Delete(int id)
        {
            if (id == 1)
                return true;
            else
                return false;

        }

        public Item GetById(int? id)
        {
            var Item = new Item
            {
                ItemID = 1,
                ItemCode = "DFGHJ",
                ItemDesc = "Dette er et kjempebra produkt",
                Category = 1,
                ImgPath = "",
                InStock = 5,
                Price = 100
            };

            if (id == 99)
                return null;
            return Item;
        }

        public List<Item> GetList()
        {
            List<Item> list = new List<Item>();
            var Item = new Item
            {
                ItemID = 1,
                ItemCode = "DFGHJ",
                ItemDesc = "Dette er et kjempebra produkt",
                Category = 1,
                ImgPath = "",
                InStock = 5,
                Price = 100
            };
            list.Add(Item);
            list.Add(Item);
            list.Add(Item);
            return list;
        }

        public Item Insert(Item inObj)
        {
            if (inObj.ItemDesc == "")
                return null;
            else
                return inObj;

        }

        public Item Update(Item obj)
        {

            if (obj == null)
                return null;

            obj.Price = 999;

            return obj;
        }
    }
}

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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Item GetById(int? id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Item Update(Item obj)
        {
            throw new NotImplementedException();
        }
    }
}

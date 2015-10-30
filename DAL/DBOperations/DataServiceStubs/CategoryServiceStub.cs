using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBOperations.DataServiceStubs
{
    public class CategoryServiceStub : IDataService<DbItemCategory, ItemCategory>
    {
        public Boolean Delete(int id)
        {
            if (id == 1)
                return true;
            else
                return false;
        }

        public ItemCategory GetById(int? id)
        {
            var ItemCat = new ItemCategory
            {
                CategoryId = 1,
                CategoryName = "TestCategory"
            };

            if (id == 99 | id == null)
                return null;

            return ItemCat;
        }

        public List<ItemCategory> GetList()
        {
            List<ItemCategory> list = new List<ItemCategory>();
            var ItemCat = new ItemCategory
            {
                CategoryId = 1,
                CategoryName = "TestCategory"
            };

            list.Add(ItemCat);
            list.Add(ItemCat);
            list.Add(ItemCat);
            return list;
        }

        public ItemCategory Insert(ItemCategory inObj)
        {
            if (inObj.CategoryName == null)
                return null;
            else
                return inObj;
        }

        public ItemCategory Update(ItemCategory obj)
        {
            if (obj == null)
                return null;
            obj.CategoryName = "NewCategory";
            return obj;
        }
    }
}

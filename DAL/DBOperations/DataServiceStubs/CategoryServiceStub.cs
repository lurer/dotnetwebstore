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
            throw new NotImplementedException();
        }

        public ItemCategory GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<ItemCategory> GetList()
        {
            throw new NotImplementedException();
        }

        public ItemCategory Insert(ItemCategory inObj)
        {
            throw new NotImplementedException();
        }

        public ItemCategory Update(ItemCategory obj)
        {
            throw new NotImplementedException();
        }
    }
}

using BOL.Models;
using DAL.DbModels;
using System;
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
            throw new NotImplementedException();
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

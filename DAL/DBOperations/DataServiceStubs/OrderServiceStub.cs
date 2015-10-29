using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBOperations.DataServiceStubs
{
    public class OrderServiceStub : IDataService<DbOrder, Order>
    {
        public Boolean Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetList()
        {
            throw new NotImplementedException();
        }

        public Order Insert(Order inObj)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}

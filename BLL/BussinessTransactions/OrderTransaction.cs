using BOL.Models;
using DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessTransactions
{
    public class OrderTransaction : ITransaction<Order>
    {
        public void Delete(int id)
        {
            new OrderService().Delete(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int? id)
        {
            return new OrderService().GetById(id);
        }

        public Order GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetList()
        {
            return new OrderService().GetList();
        }

        public void Insert(Order obj)
        {
            new OrderService().Insert(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Order obj)
        {
            new OrderService().Update(obj);
        }
    }
}

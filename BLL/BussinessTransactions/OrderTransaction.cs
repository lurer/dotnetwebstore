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

        public List<Order> GetList()
        {
            return new OrderService().GetList();
        }

        public Order Insert(Order obj)
        {
            return new OrderService().Insert(obj);
        }


        public Order Update(Order obj)
        {
            return new OrderService().Update(obj);
        }
    }
}

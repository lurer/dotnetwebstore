using BOL.Models;
using DAL.DBOperations.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessObjectOperations
{
    public class OrderBLL : InterfaceBLL<Order>
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

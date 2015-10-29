using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations;
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

        private IDataService<DbOrder, Order> service;

        public OrderBLL(IDataService<DbOrder, Order> service)
        {
            this.service = service;
        }

        public OrderBLL()
        {
            service = new OrderService();
        }


        public Boolean Delete(int id)
        {
            return service.Delete(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int? id)
        {
            return service.GetById(id);
        }

        public List<Order> GetList()
        {
            return service.GetList();
        }

        public Order Insert(Order obj)
        {
            return service.Insert(obj);
        }


        public Order Update(Order obj)
        {
            return service.Update(obj);
        }
    }
}

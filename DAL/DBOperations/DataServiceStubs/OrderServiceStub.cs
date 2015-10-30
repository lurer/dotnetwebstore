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
            if (id == 99 | id == null)
                return null;

            var order = new Order
            {
                OrderNumber = 1,
                DateTime = DateTime.Now,
                OrderPriceTotal = 100,

                User = new User
                {
                    UserID = 1,
                    FirstName = "Espen",
                    LastName = "Zaal",
                    Address = "Osloveien 123",
                    PostCode = "1234",
                    PostAddress = "Oslo",
                    Email = "test@test.no",
                    Orders = new List<Order>(),
                    Password = "Letmein",
                    RoleId = 1,
                    RoleStringId = "C",
                    Telephone = "22334455"
                },
                Items = new List<OrderLine>()

            };

            return order;
        }

        public List<Order> GetList()
        {
            var order = new Order
            {
                OrderNumber = 1,
                DateTime = DateTime.Now,
                OrderPriceTotal = 100,

                User = new User
                {
                    UserID = 1,
                    FirstName = "Espen",
                    LastName = "Zaal",
                    Address = "Osloveien 123",
                    PostCode = "1234",
                    PostAddress = "Oslo",
                    Email = "test@test.no",
                    Orders = new List<Order>(),
                    Password = "Letmein",
                    RoleId = 1,
                    RoleStringId = "C",
                    Telephone = "22334455"
                },
            };

            List<Order> list = new List<Order>();
            list.Add(order);
            list.Add(order);
            list.Add(order);

            return list;
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

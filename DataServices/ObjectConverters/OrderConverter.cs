using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectConverters
{
    public class OrderConverter : AbstractConverter<DbOrder, Order>
    {
        public override DbOrder TransFromBusinessToDb(Order obj)
        {
            var dbOrder = new DbOrder()
            {
                User = new UserConverter().TransFromBusinessToDb(obj.User),
                DateTime = obj.DateTime
            };

            var orderLineConverter = new OrderLineConverter();
            dbOrder.Items = new List<DbOrderLine>();
            foreach (var newLine in obj.Items)
            {
                dbOrder.Items.Add(orderLineConverter.TransFromBusinessToDb(newLine));
            }
            return dbOrder;
        }

        public override Order TransFromDbToBusiness(DbOrder dbObj)
        {
            var order = new Order()
            {
                OrderNumber = dbObj.OrderNumber,
                User = new UserConverter().TransFromDbToBusiness(dbObj.User),
                DateTime = dbObj.DateTime
            };
            
            var adapter = new OrderLineConverter();
            order.Items = new List<OrderLine>();
            foreach (var newLine in dbObj.Items)
            {
                order.Items.Add(adapter.TransFromDbToBusiness(newLine));
                order.OrderPriceTotal += (newLine.Item.Price - newLine.Discount);
            }
            return order;
        }
    }
}

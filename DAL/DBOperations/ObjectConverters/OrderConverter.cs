using BOL.Models;
using DAL.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DBOperations.ObjectConverters
{
    public class OrderConverter : AbstractConverter<DbOrder, Order>
    {
        public override DbOrder TransFromBusinessToDb(Order obj)
        {
            var dbOrder = new DbOrder()
            {
                UserID = obj.User.UserID,
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
            var context = new DataContext();
            foreach (var dbItemNotComplete in dbObj.Items)
            {
                var dbItemComplete = context.OrderLines.ToList().Where(x => x.OrderLineID == dbItemNotComplete.OrderLineID).FirstOrDefault();
                order.Items.Add(adapter.TransFromDbToBusiness(dbItemComplete));
                order.OrderPriceTotal += (dbItemComplete.Item.Price - dbItemComplete.Discount);
            }
            return order;
        }
    }
}

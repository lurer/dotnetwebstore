﻿using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Adapters
{
    public class OrderAdapter : AbstractAdapter<DbOrder, Order>
    {
        public override DbOrder TransFromBusinessToDb(Order obj)
        {
            var dbOrder = new DbOrder()
            {
                Customer = new CustomerAdapter().TransFromBusinessToDb(obj.Customer),
                DateTime = obj.DateTime
            };

            var adapter = new OrderLineAdapter();
            dbOrder.Items = new List<DbOrderLine>();
            foreach (var newLine in obj.Items)
            {
                dbOrder.Items.Add(adapter.TransFromBusinessToDb(newLine));
            }
            return dbOrder;
        }

        public override Order TransFromDbToBusiness(DbOrder dbObj)
        {
            var order = new Order()
            {
                OrderNumber = dbObj.OrderNumber,
                Customer = new CustomerAdapter().TransFromDbToBusiness(dbObj.Customer),
                DateTime = dbObj.DateTime
            };
            
            var adapter = new OrderLineAdapter();
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

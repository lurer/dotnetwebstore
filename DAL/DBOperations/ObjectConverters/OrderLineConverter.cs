﻿using BOL.Models;
using DAL.DbModels;

namespace DAL.DBOperations.ObjectConverters
{
    public class OrderLineConverter : AbstractConverter<DbOrderLine, OrderLine>
    {
        public override DbOrderLine TransFromBusinessToDb(OrderLine obj)
        {
            var dbLine = new DbOrderLine()
            {
                Amount = obj.Amount,
                Discount = obj.Discount,
                ItemId = obj.Item.ItemID,
            };
            return dbLine;
            
        }

        public override OrderLine TransFromDbToBusiness(DbOrderLine dbObj)
        {
            var orderLine = new OrderLine()
            {
                Amount = dbObj.Amount,
                Discount = dbObj.Discount,
                Item = new ItemConverter().TransFromDbToBusiness(dbObj.Item)
            };
            return orderLine;
        }
    }
}
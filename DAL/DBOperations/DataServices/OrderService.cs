﻿using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations.ObjectConverters;
using DAL.Utilities;
using System;
using System.Data.Entity;
using System.Data.Entity.Core;

namespace DAL.DBOperations.DataServices
{
    public class OrderService : AbstractService<DbOrder, Order>
    {


        public override Order Insert(Order inObj)
        {
            DbOrder dbOrder = transFromBusinessToDb(inObj, null);
            using(var context = new DataContext())
            {
                try
                {
                    context.Orders.Add(dbOrder);
                    context.SaveChanges();
                }
                catch (DBUpdateException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

            }
            return transFromDbToBusiness(dbOrder);
        }

        public override Order Update(Order obj)
        {
            
            using(var context = new DataContext())
            {
                DbOrder dbOrder = context.Orders.Find(obj.OrderNumber);
                dbOrder = transFromBusinessToDb(obj, dbOrder);
                try
                {
                    context.Entry(dbOrder).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DBUpdateException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }
                return transFromDbToBusiness(dbOrder);
            }
            
        }

        internal override DbOrder transFromBusinessToDb(Order obj, DbOrder dbObj)
        {
            return new OrderConverter().TransFromBusinessToDb(obj, dbObj);
        }

        internal override Order transFromDbToBusiness(DbOrder dbObj)
        {
            return new OrderConverter().TransFromDbToBusiness(dbObj);
        }
    }
}

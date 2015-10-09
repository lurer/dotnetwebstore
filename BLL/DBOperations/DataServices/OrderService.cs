using BLL.DBOperations.ObjectConverters;
using BOL.Models;
using DAL;
using DAL.DbModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DBOperations.DataServices
{
    public class OrderService : AbstractService<DbOrder, Order>
    {


        public override Order Insert(Order inObj)
        {
            DbOrder dbOrder = transFromBusinessToDb(inObj);
            using(var context = new DataContext())
            {
                context.Orders.Add(dbOrder);
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbOrder);
        }

        public override Order Update(Order obj)
        {
            DbOrder dbOrder = transFromBusinessToDb(obj);
            using(var context = new DataContext())
            {
                context.Entry(dbOrder).State = EntityState.Modified;
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbOrder);
        }

        internal override DbOrder transFromBusinessToDb(Order obj)
        {
            return new OrderConverter().TransFromBusinessToDb(obj);
        }

        internal override Order transFromDbToBusiness(DbOrder dbObj)
        {
            return new OrderConverter().TransFromDbToBusiness(dbObj);
        }
    }
}

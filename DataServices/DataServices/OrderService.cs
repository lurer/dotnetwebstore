using BOL.Models;
using DAL;
using DAL.DbModels;
using ObjectConverters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataServices
{
    public class OrderService : AbstractService<DbOrder, Order>
    {


        public override void Insert(Order inObj)
        {
            DbOrder dbOrder = transFromBusinessToDb(inObj);
            using(var context = new DataContext())
            {
                context.Orders.Add(dbOrder);
                context.SaveChanges();
            }
        }

        public override void Update(Order obj)
        {
            DbOrder dbOrder = transFromBusinessToDb(obj);
            using(var context = new DataContext())
            {
                context.Entry(dbOrder).State = EntityState.Modified;
                context.SaveChanges();
            }
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

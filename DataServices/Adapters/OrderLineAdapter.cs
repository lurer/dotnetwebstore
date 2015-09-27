using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Adapters
{
    public class OrderLineAdapter : AbstractAdapter<DbOrderLine, OrderLine>
    {
        public override DbOrderLine TransFromBusinessToDb(OrderLine obj)
        {
            var dbLine = new DbOrderLine()
            {
                Amount = obj.Amount,
                Discount = obj.Discount,
                Item = new ItemAdapter().TransFromBusinessToDb(obj.Item)
            };
            return dbLine;
            
        }

        public override OrderLine TransFromDbToBusiness(DbOrderLine dbObj)
        {
            var orderLine = new OrderLine()
            {
                Amount = dbObj.Amount,
                Discount = dbObj.Discount,
                Item = new ItemAdapter().TransFromDbToBusiness(dbObj.Item)
            };
            return orderLine;
        }
    }
}

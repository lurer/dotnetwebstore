using BOL.Models;
using DAL.DbModels;

namespace DAL.DBOperations.ObjectConverters
{
    public class OrderLineConverter : AbstractConverter<DbOrderLine, OrderLine>
    {
        public override DbOrderLine TransFromBusinessToDb(OrderLine obj, DbOrderLine dbLine)
        {
            if(dbLine == null)
            {
                dbLine = new DbOrderLine();
            }
            dbLine.Amount = obj.Amount;
            dbLine.Discount = obj.Discount;
            dbLine.ItemId = obj.Item.ItemID;
            
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

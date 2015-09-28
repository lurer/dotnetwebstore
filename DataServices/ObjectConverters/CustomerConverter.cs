using System;
using DAL.DbModels;
using BOL.Models;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectConverters
{
    public class CustomerAdapter : AbstractAdapter<DbCustomer, Customer>
    {
        public override DbCustomer TransFromBusinessToDb(Customer inCustomer)
        {
            var newCustomer = new DbCustomer()
            {
                CustomerID = inCustomer.CustomerID,
                FirstName = inCustomer.FirstName,
                LastName = inCustomer.LastName,
                Email = inCustomer.Email,
                Telephone = inCustomer.Telephone,
                Address = inCustomer.Address,
                PostCode = inCustomer.PostCode
            };
            return newCustomer;
        }

        public override Customer TransFromDbToBusiness(DbCustomer dbCustomer)
        {
            var newCustomer = new Customer()
            {
                CustomerID = dbCustomer.CustomerID,
                FirstName = dbCustomer.FirstName,
                LastName = dbCustomer.LastName,
                Email = dbCustomer.Email,
                Telephone = dbCustomer.Telephone,
                Address = dbCustomer.Address,
                PostCode = dbCustomer.PostCode,
                PostAddress = dbCustomer.PostAddress.PostAddres
            };
            return newCustomer;
        }
    }
}

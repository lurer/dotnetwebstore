using BOL.Models;
using DAL;
using DAL.DbModels;
using DataServices.Adapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Services
{
    public class CustomerService : AbstractService<DbCustomer, Customer>
    {

        public override void Insert(Customer inCustomer)
        {
            
            using (var context = new DataContext()){
                var newCustomer = transFromBusinessToDb(inCustomer);

                if(context.PostAddresses.Find(inCustomer.PostCode) == null)
                {
                    var PostAddress = new DbPostAddress()
                    {
                        PostCode = inCustomer.PostCode,
                        PostAddres = inCustomer.PostAddress
                    };
                    newCustomer.PostAddress = PostAddress;
                }

                context.Customer.Add(newCustomer);
                context.SaveChanges();
            }//using 
        }

        public override void Update(Customer obj)
        {
            DbCustomer dbCustomer = transFromBusinessToDb(obj);
            dbCustomer.PostAddress = new DbPostAddress();
            dbCustomer.PostAddress.PostCode = obj.PostCode;
            dbCustomer.PostAddress.PostAddres = obj.PostAddress;
            using(var context = new DataContext()) { 
                context.Entry(dbCustomer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        internal override DbCustomer transFromBusinessToDb(Customer inCustomer)
        {
            return new CustomerAdapter().TransFromBusinessToDb(inCustomer);
        }

        internal override Customer transFromDbToBusiness(DbCustomer dbCustomer)
        {
            return new CustomerAdapter().TransFromDbToBusiness(dbCustomer);
        }
    }
}

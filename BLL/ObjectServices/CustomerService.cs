using BLL.ObjectServices;
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

namespace BLL.ObjectServices
{
    public class CustomerService : IService<Customer>
    {
        public void Delete(int id)
        {
            using(var context = new DataContext())
            {
                var dbCustomer = context.Customer.Find(id);
                context.Customer.Remove(dbCustomer);
                context.SaveChanges();
            };
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        public Customer GetById(int? id)
        {
            using (var context = new DataContext())
            {
                var dbCustomer = context.Customer.Find(id);
                return transformDbToBusiness(dbCustomer);
            };
        }

        public Customer GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetList()
        {
            List<Customer> busList = new List<Customer>();

            using (var context = new DataContext())
            {
                var dbList = context.Customer.ToList();
                
                foreach(var dbCustomer in dbList)
                {
                    busList.Add(transformDbToBusiness(dbCustomer));
                }
            }
            return busList;
        }

        public void Insert(Customer inCustomer)
        {
            //DataContext context = new DataContext();
            
            using (var context = new DataContext()){
                var newCustomer = new DbCustomer()
                {
                    FirstName = inCustomer.FirstName,
                    LastName = inCustomer.LastName,
                    Address = inCustomer.Address,
                    PostCode = inCustomer.PostCode,
                    Email = inCustomer.Email,
                    Telephone = inCustomer.Telephone
                };

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

        public void Save()
        {
            //new DataContext().SaveChanges();
        }

        public void Update(Customer obj)
        {
            DbCustomer dbCustomer = transformBusinessToDbNoPost(obj);
            dbCustomer.PostAddress = new DbPostAddress();
            dbCustomer.PostAddress.PostCode = obj.PostCode;
            dbCustomer.PostAddress.PostAddres = obj.PostAddress;
            using(var context = new DataContext()) { 
                context.Entry(dbCustomer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        private DbCustomer transformBusinessToDbNoPost(Customer inCustomer)
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

        private Customer transformDbToBusiness(DbCustomer dbCustomer)
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

using BOL.Models;
using DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessTransactions
{
    public class CustomerTransaction : ITransaction<Customer>
    {
        private CustomerService service;

        public CustomerTransaction()
        {
            service = new CustomerService();
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Customer GetById(int? id)
        {
            return service.GetById(id);
        }

        public Customer GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetList()
        {
            return service.GetList();
        }

        public void Insert(Customer obj)
        {
            service.Insert(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            service.Update(obj);
        }
    }
}

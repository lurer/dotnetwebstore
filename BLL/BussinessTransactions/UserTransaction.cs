using BOL.Models;
using DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessTransactions
{
    public class UserTransaction : ITransaction<User>
    {
        private UserService service;

        public UserTransaction()
        {
            service = new UserService();
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public User GetById(int? id)
        {
            return service.GetById(id);
        }

        public User GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetList()
        {
            return service.GetList();
        }

        public void Insert(User obj)
        {
            service.Insert(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            service.Update(obj);
        }

        public User getUserByEmail(string emailAdr)
        {
            return service.getUserByEmail(emailAdr);
        }
    }
}

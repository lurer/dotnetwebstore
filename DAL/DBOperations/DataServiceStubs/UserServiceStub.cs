using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBOperations.DataServiceStubs
{
    public class UserServiceStub : IDataService<DbUser, User>
    {
        public Boolean Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public User Insert(User inObj)
        {
            throw new NotImplementedException();
        }

        public User Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}

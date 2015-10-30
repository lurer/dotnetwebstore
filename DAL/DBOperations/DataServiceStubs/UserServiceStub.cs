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
            if (id == 1)
                return true;
            return false;
        }

        public User GetById(int? id)
        {

            if (id == null | id == 99)
                return null;
            var User = new User
            {
                UserID = 1,
                FirstName = "Espen",
                LastName = "Zaal",
                Address = "Osloveien 123",
                PostCode = "1234",
                PostAddress = "Oslo",
                Email = "test@test.no",
                Orders = new List<Order>(),
                Password = "Letmein",
                RoleId = 1,
                RoleStringId = "C",
                Telephone = "22334455"
            };

            return User;
        }

        public List<User> GetList()
        {
            var User = new User
            {
                UserID = 1,
                FirstName = "Espen",
                LastName = "Zaal",
                Address = "Osloveien 123",
                PostCode = "1234",
                PostAddress = "Oslo",
                Email = "test@test.no",
                Orders = new List<Order>(),
                Password = "Letmein",
                RoleId = 1,
                RoleStringId = "C",
                Telephone = "22334455"
            };
            List<User> list = new List<User>();
            list.Add(User);
            list.Add(User);
            list.Add(User);

            return list;
        }

        public User Insert(User inObj)
        {
            if (inObj.FirstName == null | inObj.FirstName == "")
                return null;
            return inObj;
        }

        public User Update(User obj)
        {
            if (obj == null)
                return null;
            obj.FirstName = "NewName";
            return obj;
        }
    }
}

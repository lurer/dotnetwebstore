using DAL.DBOperations.DataServices;
using BOL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessObjectOperations
{
    public class UserBLL : InterfaceBLL<User>
    {
        private UserService service;

        public UserBLL()
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



        public List<User> GetList()
        {
            return service.GetList();
        }

        public User Insert(User obj)
        {
            return service.Insert(obj);
        }

        public User Update(User obj)
        {
            return service.Update(obj);
        }

        public User getUserByEmail(string emailAdr)
        {
            return service.getUserByEmail(emailAdr);
        }
    }
}

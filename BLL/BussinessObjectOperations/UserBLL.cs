using DAL.DBOperations.DataServices;
using BOL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBOperations;
using DAL.DbModels;

namespace BLL.BussinessObjectOperations
{
    public class UserBLL : InterfaceBLL<User>
    {

        private IDataService<DbUser, User> service;


        public UserBLL(IDataService<DbUser, User> service)
        {
            this.service = service;
        }

        public UserBLL()
        {
            service = new UserService();
        }

        public Boolean Delete(int id)
        {
            return service.Delete(id);
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
            return new UserService().getUserByEmail(emailAdr);
        }
    }
}

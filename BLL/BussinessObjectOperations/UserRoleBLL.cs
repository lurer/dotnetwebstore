using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations;
using DAL.DBOperations.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessObjectOperations
{
    public class UserRoleBLL : InterfaceBLL<Role>
    {

        private IDataService<DbRole, Role> service;

        public UserRoleBLL(IDataService<DbRole, Role> service)
        {
            this.service = service;
        }

        public UserRoleBLL()
        {
            service = new RoleService();
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Role GetById(int? id)
        {
            return service.GetById(id);
        }

        public List<Role> GetList()
        {
            return service.GetList();
        }

        public Role Insert(Role obj)
        {
            return service.Insert(obj);
        }


        public Role Update(Role obj)
        {
            return service.Update(obj);
        }
    }
}

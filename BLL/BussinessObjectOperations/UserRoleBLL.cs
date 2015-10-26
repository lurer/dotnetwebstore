using BOL.Models;
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
        public void Delete(int id)
        {
            new RoleService().Delete(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Role GetById(int? id)
        {
            return new RoleService().GetById(id);
        }

        public List<Role> GetList()
        {
            return new RoleService().GetList();
        }

        public Role Insert(Role obj)
        {
            return new RoleService().Insert(obj);
        }


        public Role Update(Role obj)
        {
            return new RoleService().Update(obj);
        }
    }
}

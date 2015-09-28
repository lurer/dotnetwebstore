using BOL.Models;
using DataServices;
using DataServices.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessTransactions
{
    public class UserRoleTransaction : ITransaction<Role>
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

        public Role GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetList()
        {
            return new RoleService().GetList();
        }

        public void Insert(Role obj)
        {
            new RoleService().Insert(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Role obj)
        {
            new RoleService().Update(obj);
        }
    }
}

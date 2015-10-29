using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBOperations.DataServiceStubs
{
    public class RoleServiceStub : IDataService<DbRole, Role>
    {
        public Boolean Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetList()
        {
            throw new NotImplementedException();
        }

        public Role Insert(Role inObj)
        {
            throw new NotImplementedException();
        }

        public Role Update(Role obj)
        {
            throw new NotImplementedException();
        }
    }
}

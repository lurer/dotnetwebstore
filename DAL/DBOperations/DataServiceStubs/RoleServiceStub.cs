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
            if (id != 1)
                return false;
            else
                return true;
        }

        public Role GetById(int? id)
        {
            if (id == 99 | id == null)
                return null;
            return new Role { RoleId = 1, RoleStringId = "C", RoleName = "Customer" };
        }

        public List<Role> GetList()
        {
            var role = new Role { RoleId = 1, RoleStringId = "C", RoleName = "Customer" };
            List<Role> list = new List<Role>();
            list.Add(role);
            list.Add(role);
            list.Add(role);
            return list;
        }

        public Role Insert(Role inObj)
        {
            if (inObj.RoleName == "")
                return null;
            return inObj;
        }

        public Role Update(Role obj)
        {
            if (obj == null)
                return null;
            obj.RoleName = "NewRole";
            return obj;
        }
    }
}

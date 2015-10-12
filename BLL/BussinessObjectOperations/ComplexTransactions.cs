using BLL.AuthenticationServices;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessObjectOperations
{
    public class ComplexTransactions
    {
        public User createUserAndUpdateRole(User User)
        {
            using (var UserService = new UserTransaction())
            {
                var RoleService = new UserRoleTransaction();
                int roleId = 0;
                try
                {
                    roleId = RoleService.GetList().Where(x => x.RoleStringId == "C").FirstOrDefault().RoleId;
                    User.RoleId = roleId;
                }
                catch (Exception)
                {
                    Role newRole = RoleService.Insert(new Role { RoleStringId = "C", RoleName = "Customer" });
                    User.RoleId = newRole.RoleId;
                }

                User.RoleStringId = "C";
                User.Password = PasswordUtility.HashMyPassword(User.Password);
                return UserService.Insert(User);
            }
            
        }



    }
}

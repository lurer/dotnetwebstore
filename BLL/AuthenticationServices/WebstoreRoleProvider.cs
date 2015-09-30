using BOL.Models;
using DAL.DbModels;
using DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace AuthenticationServices
{
    public class WebstoreRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            UserService service = new UserService();
            string[] s = { service.GetList().Where(x => x.Email == username).FirstOrDefault().RoleStringId };
            return s;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var service = new UserService();
            string[] usersFittingRole;
            List<User> users = service.GetList().Where(x => x.RoleStringId == roleName).ToList(); 
            if(users != null)
            {
                usersFittingRole = new string[users.Count];
                int counter = 0;
                foreach(var user in users)
                {
                    usersFittingRole[counter++] = user.Email;
                }
                return usersFittingRole;
            }
            return null;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using DAL.DbModels;
using BOL.Models;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DBOperations.ObjectConverters
{
    public class UserConverter : AbstractConverter<DbUser, User>
    {
        public override DbUser TransFromBusinessToDb(User inUser)
        {
            var newUser = new DbUser()
            {
                UserID = inUser.UserID,
                FirstName = inUser.FirstName,
                LastName = inUser.LastName,
                Email = inUser.Email,
                Password = inUser.Password,
                Telephone = inUser.Telephone,
                Address = inUser.Address,
                PostCode = inUser.PostCode,
                RoleId = inUser.RoleId,
                RoleStringId = inUser.RoleStringId
            };

            return newUser;
        }

        public override User TransFromDbToBusiness(DbUser dbUser)
        {
            if (dbUser != null)
            {
                var newUser = new User()
                {

                    UserID = dbUser.UserID,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email,
                    Password = dbUser.Password,
                    Telephone = dbUser.Telephone,
                    Address = dbUser.Address,
                    PostCode = dbUser.PostCode,
                    PostAddress = dbUser.PostAddress.PostAddres,
                    Orders = new List<Order>(),
                    RoleId = dbUser.RoleId,
                    RoleStringId = dbUser.RoleStringId
                };
                return newUser;
            }

            return null;
            
            
        }
    }
}

using BLL.DBOperations.ObjectConverters;
using BOL.Models;
using DAL;
using DAL.DbModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DBOperations.DataServices
{
    public class UserService : AbstractService<DbUser, User>
    {

        public override User Insert(User inUser)
        {
            
            using (var context = new DataContext()){
                var dbUser = transFromBusinessToDb(inUser);

                if(context.Users.ToList().Where(x=>x.Email == dbUser.Email).Count() > 0)
                    return null;
                
                if(context.PostAddresses.Find(inUser.PostCode) == null)
                {
                    var PostAddress = new DbPostAddress()
                    {
                        PostCode = inUser.PostCode,
                        PostAddres = inUser.PostAddress
                    };
                    dbUser.PostAddress = PostAddress;
                }

                context.Users.Add(dbUser);
                context.SaveChanges();

                return transFromDbToBusiness(dbUser);
            }//using 
        }

        public override User Update(User obj)
        {
            DbUser dbUser = transFromBusinessToDb(obj);
/*            if(obj.Orders != null)
            {
                var orderConverter = new OrderConverter();
                dbUser.Orders = new List<DbOrder>();
                foreach(var inOrder in obj.Orders)
                {
                    dbUser.Orders.Add(orderConverter.TransFromBusinessToDb(inOrder));
                }
            } */


            dbUser.PostAddress = new DbPostAddress();
            dbUser.PostAddress.PostCode = obj.PostCode;
            dbUser.PostAddress.PostAddres = obj.PostAddress;
            using(var context = new DataContext()) { 
                context.Entry(dbUser).State = EntityState.Modified;
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbUser);
        }


        internal override DbUser transFromBusinessToDb(User inUser)
        {
            return new UserConverter().TransFromBusinessToDb(inUser);
        }

        internal override User transFromDbToBusiness(DbUser dbUser)
        {
            return new UserConverter().TransFromDbToBusiness(dbUser);
        }

        public User getUserByEmail(string emailAdr)
        {
            DbUser dbUser = new DataContext().Users.ToList().Where(x => x.Email == emailAdr).FirstOrDefault();
            return transFromDbToBusiness(dbUser);
        }
    }
}

using BOL.Models;
using DAL.DbModels;
using DAL.DBOperations.ObjectConverters;
using DAL.Utilities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.DBOperations.DataServices
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

                try
                {
                    context.Users.Add(dbUser);
                    context.SaveChanges();
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }


                return transFromDbToBusiness(dbUser);
            }//using 
        }

        public override User Update(User obj)
        {
            DbUser dbUser = transFromBusinessToDb(obj);

            dbUser.PostAddress = new DbPostAddress();
            dbUser.PostAddress.PostCode = obj.PostCode;
            dbUser.PostAddress.PostAddres = obj.PostAddress;
            using(var context = new DataContext()) {

                try
                {
                    context.Entry(dbUser).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

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

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
                var dbUser = transFromBusinessToDb(inUser, null);
                
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
                catch (DBUpdateException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }


                return transFromDbToBusiness(dbUser);
            }//using 
        }

        public override User Update(User obj)
        {

            using (var context = new DataContext())
            {
                DbUser dbUser = context.Users.Find(obj.UserID);
                dbUser = transFromBusinessToDb(obj, dbUser);

                dbUser.PostAddress = new DbPostAddress();
                dbUser.PostAddress.PostCode = obj.PostCode;
                dbUser.PostAddress.PostAddres = obj.PostAddress;
                try
                {
                    context.Entry(dbUser).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DBUpdateException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }
                return transFromDbToBusiness(dbUser);
            }
            
        }


        internal override DbUser transFromBusinessToDb(User inUser, DbUser dbUser)
        {
            return new UserConverter().TransFromBusinessToDb(inUser, dbUser);
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

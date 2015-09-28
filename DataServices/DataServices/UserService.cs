using BOL.Models;
using DAL;
using DAL.DbModels;
using ObjectConverters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public class UserService : AbstractService<DbUser, User>
    {

        public override void Insert(User inUser)
        {
            
            using (var context = new DataContext()){
                var newUser = transFromBusinessToDb(inUser);

                if(context.PostAddresses.Find(inUser.PostCode) == null)
                {
                    var PostAddress = new DbPostAddress()
                    {
                        PostCode = inUser.PostCode,
                        PostAddres = inUser.PostAddress
                    };
                    newUser.PostAddress = PostAddress;
                }

                context.Users.Add(newUser);
                context.SaveChanges();
            }//using 
        }

        public override void Update(User obj)
        {
            DbUser dbUser = transFromBusinessToDb(obj);
            dbUser.PostAddress = new DbPostAddress();
            dbUser.PostAddress.PostCode = obj.PostCode;
            dbUser.PostAddress.PostAddres = obj.PostAddress;
            using(var context = new DataContext()) { 
                context.Entry(dbUser).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        internal override DbUser transFromBusinessToDb(User inUser)
        {
            return new UserConverter().TransFromBusinessToDb(inUser);
        }

        internal override User transFromDbToBusiness(DbUser dbUser)
        {
            return new UserConverter().TransFromDbToBusiness(dbUser);
        }
    }
}

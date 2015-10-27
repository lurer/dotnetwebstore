using DAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DBOperations.DataServices
{
    public abstract class AbstractService<T, R> : IDataService<T,R> where T : class
    {
        
        public void Delete(int id)
        {
            using (var context = new DataContext())
            {

                try
                {
                    var dbObj = context.Set<T>().Find(id);
                    context.Set<T>().Remove(dbObj);
                    context.SaveChanges();
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }
            };
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        public R GetById(int? id)
        {
            
            using (var context = new DataContext())
            {
                try
                {
                    var dbObj = context.Set<T>().Find(id);
                    return transFromDbToBusiness(dbObj);
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

            };
            return default(R);            

        }


        public List<R> GetList()
        {
            List<R> busList = new List<R>();

            using (var context = new DataContext())
            {
                try
                {
                    var dbList = context.Set<T>().ToList();
                    foreach (var dbObj in dbList)
                    {
                        busList.Add(transFromDbToBusiness(dbObj));
                    }
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

            }
            return busList;
        }


        public abstract R Insert(R inObj);

        public abstract R Update(R obj);
              

        internal abstract R transFromDbToBusiness(T dbObj);

        internal abstract T transFromBusinessToDb(R obj);
    }
}

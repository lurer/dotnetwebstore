﻿using DAL.Utilities;
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

                var dbObj = context.Set<T>().Find(id);
                if (dbObj == null)
                    throw new CustomDbException();

                context.Set<T>().Remove(dbObj);
                context.SaveChanges();
  

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
                var dbObj = context.Set<T>().Find(id);
                if (dbObj == null)
                    throw new CustomDbException();
                return transFromDbToBusiness(dbObj);
            };
            

        }


        public List<R> GetList()
        {
            List<R> busList = new List<R>();

            using (var context = new DataContext())
            {
                var dbList = context.Set<T>().ToList();
                if(dbList == null)
                    throw new CustomDbException();

                foreach (var dbObj in dbList)
                {
                    busList.Add(transFromDbToBusiness(dbObj));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectServices
{
    public abstract class AbstractService<T, R> where T : class
    {
        
        public void Delete(int id)
        {
            using (var context = new DataContext())
            {
                       
                var dbObj = context.Set<T>().Find(id);
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
                return transfromDbToBusiness(dbObj);
            };
        }

        public T GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<R> GetList()
        {
            List<R> busList = new List<R>();

            using (var context = new DataContext())
            {
                var dbList = context.Set<T>().ToList();

                foreach (var dbObj in dbList)
                {
                    busList.Add(transfromDbToBusiness(dbObj));
                }
            }
            return busList;
        }

        public void Save()
        {
            //new DataContext().SaveChanges();
        }

        public abstract void Insert(R inObj);

        public abstract void Update(R obj);
              

        internal abstract R transfromDbToBusiness(T dbObj);

        internal abstract T transFromBusinessToDb(R obj);
    }
}

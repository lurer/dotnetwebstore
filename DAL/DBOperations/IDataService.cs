using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBOperations
{
    public interface IDataService<T, R> where T : class
    {
        Boolean Delete(int id);

        R GetById(int? id);

        List<R> GetList();

        R Insert(R inObj);

        R Update(R obj);


    }
}

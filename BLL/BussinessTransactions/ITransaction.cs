using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessTransactions
{
    public interface ITransaction<T> : IDisposable
    {
        List<T> GetList();
        T GetById(int? id);
        
        T Insert(T obj);
        void Delete(int id);
        T Update(T obj);

    }
}

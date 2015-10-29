using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessObjectOperations
{
    public interface InterfaceBLL<T> : IDisposable
    {
        List<T> GetList();
        T GetById(int? id);
        
        T Insert(T obj);
        Boolean Delete(int id);
        T Update(T obj);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectServices
{
    public interface IService<T> : IDisposable
    {
        List<T> GetList();
        T GetById(int? id);
        T GetByStringId(String id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        void Save();
    }
}

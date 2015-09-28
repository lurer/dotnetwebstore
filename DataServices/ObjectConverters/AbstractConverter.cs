using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectConverters
{
    public abstract class AbstractAdapter<T, R> where T : class
    {
        public abstract R TransFromDbToBusiness(T dbObj);
        public abstract T TransFromBusinessToDb(R obj);
    }
}

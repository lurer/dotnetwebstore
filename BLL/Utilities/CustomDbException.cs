using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities
{
    public class CustomDbException : Exception
    {

        public override string Message
        {
            get
            {
                return base.Message;
            }
            
        }
    }
}

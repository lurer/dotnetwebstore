using System;

namespace DAL.Utilities
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

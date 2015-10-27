using System;
using System.Data.Entity.Core;
using System.IO;
using System.Text;

namespace DAL.Utilities
{


    public enum SEVERITY { INFO, WARNING, ERROR, SEVERE }


    public class CustomDbException : EntityException
    {
        
        static string SQLLOG = "App_Data/sql_error_log.txt";

        public void logToFile(SEVERITY type, DateTime timeStamp, String msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(timeStamp.ToLongTimeString()).Append(": ").Append(type.ToString()).Append("\n");
            sb.Append(msg).Append("\n\n");

            try
            {
                StreamWriter sw = new StreamWriter(SQLLOG, true);
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
            catch (Exception)
            {

            }
        }


    }
}

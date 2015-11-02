using System;
using System.Data.Entity.Core;
using System.IO;
using System.Text;

namespace DAL.Utilities
{


    public enum SEVERITY { INFO, WARNING, ERROR, SEVERE }


    public class DBUpdateException : EntityException
    {
        
        static string SQLLOG = "sql_error_log.txt";
        static string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

        public void logToFile(SEVERITY type, DateTime timeStamp, String msg)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(timeStamp.ToLongTimeString()).Append(": ").Append(type.ToString()).Append(" ").Append(this.StackTrace);

            try
            {
                StreamWriter sw = new StreamWriter(path+"/"+SQLLOG, true);
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
            catch (Exception)
            {

            }
        }


    }
}

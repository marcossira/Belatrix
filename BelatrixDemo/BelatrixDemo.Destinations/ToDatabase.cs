using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixDemo.Library;
using System.Data.SqlClient;
using System.Configuration;

namespace BelatrixDemo.Destinations
{
    public class ToDatabase : IJobLogger
    {
        public bool LogMessage(string message, LogType logType, MessageTypeToLog messageTypeToLog)
        {
            bool value = true;

            int typeMessage = (int)logType;
            string conexion = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                string sqlQuery = string.Format("Insert into Log Values('{0}', {1})", message, typeMessage.ToString());
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        conexion.Clone();
                        value = false;
                    }
                }
            }
            return value;
        }
    }
}

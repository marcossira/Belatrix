using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using BelatrixDemo.Library;


namespace BelatrixDemo.Destinations
{
    public class ToFile : IJobLogger 
    {
        public bool LogMessage(string message, LogType logType, MessageTypeToLog messageTypeToLog)
        {
            bool value = true;
            try
            {
                int typeMessage = (int)logType;
                string line = string.Empty;
                string directory = ConfigurationManager.AppSettings["LogFileDirectory"];
                string stringDate = DateTime.Now.ToShortDateString();
                string fullPath = string.Format("{0}{1}.txt", directory, stringDate);

                line = string.Format("{0}|{1}|{0}\n", DateTime.Now.ToShortDateString(), message, typeMessage);

                //this method create the files if doesnt exist
                File.AppendAllText(fullPath, line);

            }
            catch (Exception)
            {
                value = false;
            }
            return value;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixDemo.Library;

namespace BelatrixDemo.Destinations
{
    public class ToConsole : IJobLogger 
    {
        public bool LogMessage(string message, LogType logType, MessageTypeToLog messageTypeToLog)
        {
            try
            {                
                switch (logType)
                {
                    case LogType.none:
                        break;
                    case LogType.Message:
                        if (messageTypeToLog.Message)
                            Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case LogType.Error:
                        if (messageTypeToLog.Error)
                            Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogType.Warning:
                        if (messageTypeToLog.Warning)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        break;
                }
                Console.WriteLine(DateTime.Now.ToShortDateString() + message);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }
    }
}

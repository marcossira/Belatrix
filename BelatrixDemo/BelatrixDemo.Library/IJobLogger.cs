using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixDemo.Library
{
    public enum LogType
    {
        none = 0,
        Message = 1,
        Error = 2,
        Warning = 3
    }

    public interface IJobLogger
    {
        bool LogMessage(string message, LogType logType, MessageTypeToLog messageTypeToLog);
    }
}

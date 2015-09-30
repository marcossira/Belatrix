using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixDemo.Library
{
    public class MessageTypeToLog
    {
        public bool Message { get; set; }
        public bool Error { get; set; }
        public bool Warning { get; set; }
        public MessageTypeToLog(bool message, bool error, bool warning)
        {
            Message = message;
            Error = error;
            Warning = warning;
        }
        public bool IsValid()
        {
            return Message || Error || Warning;
        }
    }
}

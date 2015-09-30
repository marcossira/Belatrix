using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixDemo.Library;
using BelatrixDemo.Destinations;

namespace BelatrixDemo.Business
{
    public class JobLogger
    {
        private static LogDestiny LogDestiny { get; set; }
        private static MessageTypeToLog MessageTypeToLog { get; set; }

        public JobLogger(LogDestiny logDestiny, MessageTypeToLog messageTypeToLog)
        {
            LogDestiny = logDestiny;
            MessageTypeToLog = messageTypeToLog;
        }

        private static bool IsValid(string message, LogType logType)
        {
            bool value = true;
            message.Trim();
            if (message == null || message.Length == 0)
                value = false;

            bool isDestinyValid = LogDestiny.IsValid();
            if (!isDestinyValid)
                throw new Exception("Invalid configuration");

            bool IsValidTypeToLog = MessageTypeToLog.IsValid();
            if (!IsValidTypeToLog || logType == LogType.none)
                throw new Exception("Error or Warning or Message must be specified");

            bool whenToSave = false;
            switch (logType)
            {
                case LogType.none:
                    break;
                case LogType.Message:
                    if (MessageTypeToLog.Message)
                        whenToSave = true;
                    break;
                case LogType.Error:
                    if (MessageTypeToLog.Error)
                        whenToSave = true;
                    break;
                case LogType.Warning:
                    if (MessageTypeToLog.Warning)
                        whenToSave = true;
                    break;
                default:
                    break;
            }
            return value && whenToSave;
        }


        private static bool SaveMessage(string message, LogType logType)
        {
            IJobLogger JobLogger;
            bool controlConsole = false;
            bool controlDB = false;
            bool controlFile = false;

            if (LogDestiny.ToDatabase)
            { 
                JobLogger = (IJobLogger)Activator.CreateInstance(typeof(ToDatabase));
                controlDB = JobLogger.LogMessage(message, logType, MessageTypeToLog);
            }

            if (LogDestiny.ToFile)
            {
                JobLogger = (IJobLogger)Activator.CreateInstance(typeof(ToFile));
                controlFile = JobLogger.LogMessage(message, logType, MessageTypeToLog);
            }

            if (LogDestiny.ToConsole)
            {
                JobLogger = (IJobLogger)Activator.CreateInstance(typeof(ToConsole));
                controlConsole = JobLogger.LogMessage(message, logType, MessageTypeToLog);
            }

                return controlDB || controlFile || controlConsole;
        }

        public bool LogMessage(string msg, LogType logType)
        {          
            try
            {
                if (!LogDestiny.IsValid())
                {
                    throw new Exception("Invalid configuration");
                }

                msg.Trim();
                bool value = IsValid(msg, logType);
                if (!value)
                    return false;
                bool IsSaved = SaveMessage(msg, logType);
                return IsSaved;
            }
            catch (Exception ex)
            {
                return false;           
            }
            
            
        }

    }
}
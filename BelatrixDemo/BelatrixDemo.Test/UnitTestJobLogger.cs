using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BelatrixDemo.Business;
using BelatrixDemo.Library;

namespace BelatrixDemo.Test
{
    [TestClass]
    public class UnitTestJobLogger
    {
        [TestMethod]
        public void JobLogger_LogMessage_ToFile_Message()
        {
            LogDestiny Destiny = new LogDestiny(false, false, true);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);
            
            JobLogger Objeto = new JobLogger(Destiny, TypeLog);
            bool control = Objeto.LogMessage("TEST MESSAGE", LogType.Message);

            Assert.IsTrue(!control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToConsole_Message()
        {
            LogDestiny Destiny = new LogDestiny(true, false, false);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Object = new JobLogger(Destiny, TypeLog);
            bool control = Object.LogMessage("TEST MESSAGE", LogType.Message);

            Assert.IsTrue(control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToDataBase_Message()
        {
            LogDestiny Destiny = new LogDestiny(false, true, false);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Object = new JobLogger(Destiny, TypeLog);
            bool control = Object.LogMessage("TEST MESSAGE", LogType.Message);

            Assert.IsTrue(!control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToFile_Error()
        {
            LogDestiny Destiny = new LogDestiny(false, false, true);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Objeto = new JobLogger(Destiny, TypeLog);
            bool control = Objeto.LogMessage("TEST MESSAGE", LogType.Error);

            Assert.IsTrue(!control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToConsole_Error()
        {
            LogDestiny Destiny = new LogDestiny(true, false, false);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Object = new JobLogger(Destiny, TypeLog);
            bool control = Object.LogMessage("TEST MESSAGE", LogType.Error);

            Assert.IsTrue(control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToDataBase_Error()
        {
            LogDestiny Destiny = new LogDestiny(false, true, false);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Object = new JobLogger(Destiny, TypeLog);
            bool control = Object.LogMessage("TEST MESSAGE", LogType.Error);

            Assert.IsTrue(!control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToFile_Warning()
        {
            LogDestiny Destiny = new LogDestiny(false, false, true);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Objeto = new JobLogger(Destiny, TypeLog);
            bool control = Objeto.LogMessage("TEST MESSAGE", LogType.Warning);

            Assert.IsTrue(!control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToConsole_Warning()
        {
            LogDestiny Destiny = new LogDestiny(true, false, false);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Object = new JobLogger(Destiny, TypeLog);
            bool control = Object.LogMessage("TEST MESSAGE", LogType.Warning);

            Assert.IsTrue(control);
        }

        [TestMethod]
        public void JobLogger_LogMessage_ToDataBase_Warning()
        {
            LogDestiny Destiny = new LogDestiny(false, true, false);
            MessageTypeToLog TypeLog = new MessageTypeToLog(true, true, true);

            JobLogger Object = new JobLogger(Destiny, TypeLog);
            bool control = Object.LogMessage("TEST MESSAGE", LogType.Warning);

            Assert.IsTrue(!control);
        }
    }
}

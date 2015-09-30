using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixDemo.Library
{
    public class LogDestiny
    {
        public bool ToConsole { get; set; }
        public bool ToDatabase { get; set; }
        public bool ToFile { get; set; }

        public LogDestiny(bool toConsole, bool toDatabase, bool toFile)
        {
            ToConsole = toConsole;
            ToDatabase = toDatabase;
            ToFile = toFile;
        }

        public bool IsValid()
        {
            return ToConsole || ToDatabase || ToFile;
        }
    }
}

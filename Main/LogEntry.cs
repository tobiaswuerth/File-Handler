using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.wuerth.tobias.filehandler.Main
{
    using System.Drawing;
    using System.Security.Policy;

    using Plugin;

    public class LogEntry
    {
        public enum LogType
        {
            Information, Warning, Error    
        }
        public static readonly Dictionary<LogType, Color> LogTypeColors = new Dictionary<LogType, Color>
                                                                          {
                                                                              
                                                                          };

        public PluginBase Plugin { get; set; }
        public String Data { get; set; }
        public LogType Type { get; set; }
    }
}

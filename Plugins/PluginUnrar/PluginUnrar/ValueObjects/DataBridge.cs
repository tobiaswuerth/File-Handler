using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginUnrar.ValueObjects
{
    using ch.wuerth.tobias.filehandler.PluginUnzip.Enum;

    public class DataBridge
    {
        public String WinrarDirectory { get; set; }
        public Boolean CreateSubdirectory { get; set; }
        public Boolean DeleteArchiveAfterExtraction { get; set; }
        public Boolean UsePasswords { get; set; }
        public List<String> Passwords { get; set; }
        public Status Status { get; set; }
    }
}

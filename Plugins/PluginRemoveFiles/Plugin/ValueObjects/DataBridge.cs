using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.wuerth.tobias.filehandler.PluginRemoveFiles.ValueObjects
{
    using Enums;

    public class DataBridge
    {
        public List<String> Extensions
        {
            get;
            set;
        } = new List<String>();

        public Status Status
        {
            get;
            set;
        } = Status.Unknown;
    }
}

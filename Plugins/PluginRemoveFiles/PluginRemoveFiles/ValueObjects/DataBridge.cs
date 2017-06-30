namespace ch.wuerth.tobias.filehandler.PluginRemoveFiles.ValueObjects
{
    #region usings

    using System;
    using System.Collections.Generic;

    using Enums;

    #endregion

    public class DataBridge
    {
        public List<String> Extensions { get; set; } = new List<String>();

        public Status Status { get; set; } = Status.Unknown;
    }
}
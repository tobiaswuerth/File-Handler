namespace ch.wuerth.tobias.filehandler.PluginUnzip.ValueObjects
{
    #region usings

    using System;

    using Enum;

    #endregion

    public class DataBridge
    {
        public Boolean? CreateSubdir { get; set; }
        public Boolean? DeleteArchive { get; set; }
        public Status Status { get; set; } = Status.Unknown;
    }
}
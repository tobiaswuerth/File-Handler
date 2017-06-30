namespace ch.wuerth.tobias.filehandler.Core.Interfaces
{
    #region usings

    using ValueObjects;

    #endregion

    public interface ILogger
    {
        void Log(LogEntry entry);
    }
}
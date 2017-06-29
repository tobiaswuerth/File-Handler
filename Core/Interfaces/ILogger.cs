namespace ch.wuerth.tobias.filehandler.Core.Interfaces
{
    using ValueObjects;

    public interface ILogger
    {
        void Log(LogEntry entry);
    }
}
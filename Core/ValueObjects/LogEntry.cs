namespace ch.wuerth.tobias.filehandler.Core.ValueObjects
{
    using System;
    using Enums;

    public class LogEntry
    {
        public DateTime Timestamp
        {
            get;
        } = DateTime.Now;

        public String Sender
        {
            get;
        }

        public String Data
        {
            get;
        }

        public LogType Type
        {
            get;
        }

        public LogEntry(String sender, String data, LogType type)
        {
            Sender = sender;
            Data = data;
            Type = type;
        }
    }
}
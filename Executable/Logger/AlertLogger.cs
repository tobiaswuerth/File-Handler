namespace ch.wuerth.tobias.filehandler.Executable.Logger
{
    #region usings

    using System.Collections.Generic;
    using System.Windows.Forms;
    using Core.Enums;
    using Core.Interfaces;
    using Core.ValueObjects;

    #endregion

    public class AlertLogger : ILogger
    {
        private static readonly Dictionary<LogType, MessageBoxIcon> LOG_TYPE_COLORS = new Dictionary<LogType, MessageBoxIcon>
                                                                                      {
                                                                                          {
                                                                                              LogType.Information, MessageBoxIcon.Information
                                                                                          },
                                                                                          {
                                                                                              LogType.Warning, MessageBoxIcon.Warning
                                                                                          },
                                                                                          {
                                                                                              LogType.Error, MessageBoxIcon.Error
                                                                                          }
                                                                                      };

        public void Log(LogEntry entry)
        {
            MessageBox.Show(null, entry.Data, entry.Sender, MessageBoxButtons.OK, GetColorByLogType(entry.Type));
        }

        private static MessageBoxIcon GetColorByLogType(LogType type)
        {
            return LOG_TYPE_COLORS.ContainsKey(type) ? LOG_TYPE_COLORS[type] : MessageBoxIcon.None;
        }
    }
}
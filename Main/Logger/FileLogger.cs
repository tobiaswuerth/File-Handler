﻿namespace ch.wuerth.tobias.filehandler.Main.Logger
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Core.Enums;
    using Core.Interfaces;
    using Core.ValueObjects;

    public class FileLogger : ILogger
    {
        private const String LOGS_FOLDER = "logs";

        private static readonly Dictionary<LogType, String> LOG_TYPE_PREFIX = new Dictionary<LogType, String>
                                                                              {
                                                                                  {
                                                                                      LogType.Error, "[EXCEPTION]"
                                                                                  },
                                                                                  {
                                                                                      LogType.Information, "[*]"
                                                                                  },
                                                                                  {
                                                                                      LogType.Warning, "[WARNING]"
                                                                                  }
                                                                              };

        private readonly Dictionary<LogType, Boolean> _logLogTypes = new Dictionary<LogType, Boolean>
                                                                     {
                                                                         {
                                                                             LogType.Error, true
                                                                         },
                                                                         {
                                                                             LogType.Information, false
                                                                         },
                                                                         {
                                                                             LogType.Warning, true
                                                                         }
                                                                     };

        private readonly String _path = $"{LOGS_FOLDER}/log_{DateTime.Today:yy-MM-dd}";
        private volatile TextWriter _sw;

        public Boolean LogErrors
        {
            get
            {
                return _logLogTypes[LogType.Error];
            }
            set
            {
                _logLogTypes[LogType.Error] = value;
            }
        }

        public Boolean LogWarnings
        {
            get
            {
                return _logLogTypes[LogType.Warning];
            }
            set
            {
                _logLogTypes[LogType.Warning] = value;
            }
        }

        public Boolean LogInformations
        {
            get
            {
                return _logLogTypes[LogType.Information];
            }
            set
            {
                _logLogTypes[LogType.Information] = value;
            }
        }

        public FileLogger()
        {
            if (!Directory.Exists(LOGS_FOLDER))
            {
                Directory.CreateDirectory(LOGS_FOLDER);
            }
            _sw = new StreamWriter(_path);
            _sw = TextWriter.Synchronized(_sw);
        }

        public void Log(LogEntry entry)
        {
            if (!_logLogTypes[entry.Type])
            {
                return;
            }

            _sw.WriteLine($"{GetLogTypePrefixByType(entry.Type)}\t{entry.Timestamp:T}\t{entry.Sender}\t{entry.Data}");
        }

        private static String GetLogTypePrefixByType(LogType type)
        {
            return LOG_TYPE_PREFIX.ContainsKey(type) ? LOG_TYPE_PREFIX[type] : $"[{type}]";
        }
    }
}
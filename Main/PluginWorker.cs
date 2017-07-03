namespace ch.wuerth.tobias.filehandler.Main
{
    #region usings

    using System;
    using System.IO;
    using System.Threading;

    using Core.Enums;
    using Core.Interfaces;
    using Core.ValueObjects;

    using Plugin;

    #endregion

    internal class PluginWorker
    {
        public delegate (String, PluginBase) GetNextFile();

        private readonly ILogger _logger;
        private readonly GetNextFile _methodGetNextFile;
        public readonly Guid Guid = Guid.NewGuid();
        private volatile Boolean _isRunning;
        private Thread _thread;
        public Boolean IsWorking { get; private set; }

        public Boolean IsRunning { get => _isRunning; private set => _isRunning = value; }

        public PluginWorker(GetNextFile methodGetNextFile, ILogger logger)
        {
            _methodGetNextFile = methodGetNextFile ?? throw new ArgumentNullException();
            _logger = logger;
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
            }
        }

        public void Start()
        {
            if (IsRunning)
            {
                return;
            }

            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            IsRunning = true;
            while (IsRunning)
            {
                (String, PluginBase) nextTask = _methodGetNextFile.Invoke();
                String file = nextTask.Item1;
                PluginBase plugin = nextTask.Item2;

                if (null == file)
                {
                    // no tasks left
                    Stop();
                    break;
                }

                if (null == plugin)
                {
                    // no plugin found
                    _logger.Log(new LogEntry($"Plugin Worker ({Guid})", $"No plugin provided for filetype '{Path.GetFileName(file)}'", LogType.Information));
                    continue;
                }

                try
                {
                    IsWorking = true;
                    plugin.Action(file);
                    IsWorking = false;
                }
                catch (Exception ex)
                {
                    _logger.Log(new LogEntry($"Plugin Worker ({Guid})", ex.Message, LogType.Error));
                }
            }

            IsRunning = false;
        }
    }
}
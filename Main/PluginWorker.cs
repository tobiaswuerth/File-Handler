namespace ch.wuerth.tobias.filehandler.Main
{
    #region usings

    using System;
    using System.IO;
    using System.Threading;

    using Plugin;

    #endregion

    internal class PluginWorker
    {
        public delegate (String, PluginBase) GetNextFile();

        public delegate void Log(String message, PluginWorker worker);

        private readonly GetNextFile _methodGetNextFile;
        private readonly Log _methodLog;
        public readonly Guid Guid = Guid.NewGuid();
        private volatile Boolean _isRunning;

        private Thread _thread;

        public Boolean IsRunning { get => _isRunning; private set => _isRunning = value; }

        public PluginWorker(GetNextFile methodGetNextFile, Log methodLog)
        {
            _methodGetNextFile = methodGetNextFile ?? throw new ArgumentNullException();
            _methodLog = methodLog;
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

                if (null == plugin)
                {
                    // no plugin found
                    _methodLog?.Invoke($"No plugin provided for filetype '{Path.GetFileName(file)}'", this);
                    continue;
                }

                if (null == file)
                {
                    // no tasks left
                    Stop();
                    break;
                }

                plugin.Action(file);
            }
        }
    }
}
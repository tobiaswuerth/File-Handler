namespace ch.wuerth.tobias.filehandler.Executable
{
    #region usings

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Core.Enums;
    using Core.Interfaces;
    using Core.ValueObjects;

    #endregion

    internal class Crawler
    {
        public delegate void OnDoneEvent();

        private const Int32 BUFFER_THRESHOLD_SLEEP = 25; //ms
        private const Int32 BUFFER_EMPTY_SLEEP = 1; //ms
        private const Int32 BUFFER_FILL_THRESHOLD = 1000;
        private const Int32 TRY_DEQUEUE_FAILED_SLEEP_DELAY = 1; // ms
        private readonly ILogger _logger;
        private readonly String _rootDirectory;
        private volatile ConcurrentQueue<String> _fileBuffer = new ConcurrentQueue<String>();
        private Boolean _isDone;
        private volatile Boolean _isRunning;
        private volatile Boolean _recursiveCrawling;
        private Thread _thread;

        public OnDoneEvent OnDone { get; set; }

        public Boolean IsRunning { get => _isRunning; private set => _isRunning = value; }

        public Boolean IsDone
        {
            get => _isDone;
            private set
            {
                _isDone = value;
                if (IsDone)
                {
                    OnDone?.Invoke();
                }
            }
        }

        public Crawler(String rootDirectory, Boolean recursiveCrawling, ILogger logger)
        {
            _rootDirectory = rootDirectory;
            _recursiveCrawling = recursiveCrawling;
            _logger = logger;
        }

        public String GetNextFile()
        {
            while (!IsDone)
            {
                String nextFile;
                while (!_fileBuffer.TryDequeue(out nextFile) && !(!_fileBuffer.Any() && !IsRunning))
                {
                    Thread.Sleep(TRY_DEQUEUE_FAILED_SLEEP_DELAY);
                }

                if (null == nextFile)
                {
                    if (!IsRunning)
                    {
                        IsDone = true;
                        break;
                    }

                    Thread.Sleep(BUFFER_EMPTY_SLEEP);
                }
                else
                {
                    return nextFile;
                }
            }

            return null;
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
            IsDone = false;
            Crawl(_rootDirectory);
            IsRunning = false;
        }

        private void Crawl(String directory)
        {
            if (!IsRunning)
            {
                return;
            }
            if (!Directory.Exists(directory))
            {
                return;
            }

            List<String> files = null;
            try
            {
                files = Directory.GetFiles(directory).ToList();
            }
            catch (Exception ex)
            {
                _logger.Log(new LogEntry("File Crawler", $"An exception occurred: {ex.Message}", LogType.Error));
                return;
            }

            do
            {
                Int32 bufferCount;
                lock (_fileBuffer)
                {
                    bufferCount = _fileBuffer.Count;
                }
                if (bufferCount < BUFFER_FILL_THRESHOLD)
                {
                    break;
                }

                Thread.Sleep(BUFFER_THRESHOLD_SLEEP);
                if (!IsRunning)
                {
                    return;
                }
            }
            while (true);

            lock (_fileBuffer)
            {
                files.ForEach(x => _fileBuffer.Enqueue(x));
            }
            if (!_recursiveCrawling)
            {
                return;
            }
            if (!IsRunning)
            {
                return;
            }

            List<String> directories = Directory.GetDirectories(directory).ToList();
            directories.ForEach(Crawl);
        }
    }
}
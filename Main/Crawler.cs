namespace ch.wuerth.tobias.filehandler.Main
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
        private const Int32 BUFFER_THRESHOLD_SLEEP = 250; //ms
        private const Int32 BUFFER_EMPTY_SLEEP = 250; //ms
        private const Int32 BUFFER_FILL_THRESHOLD = 50;
        private readonly ILogger _logger;
        private readonly String _rootDirectory;
        private volatile ConcurrentQueue<String> _fileBuffer = new ConcurrentQueue<String>();
        private volatile Boolean _isRunning;
        private volatile Boolean _recursiveCrawling;
        private Thread _thread;

        public Boolean IsRunning
        {
            get
            {
                return _isRunning;
            }
            private set
            {
                _isRunning = value;
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
            while (IsRunning)
            {
                String nextFile;
                while (!_fileBuffer.TryDequeue(out nextFile))
                {
                    Thread.Sleep(50);
                }

                if (null == nextFile)
                {
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
            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            IsRunning = true;
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
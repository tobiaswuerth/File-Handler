namespace ch.wuerth.tobias.filehandler.Main
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;

    #endregion

    internal class Crawler
    {
        private const Int32 BUFFER_THRESHOLD_SLEEP = 250; //ms
        private const Int32 BUFFER_EMPTY_SLEEP = 250; //ms
        private const Int32 BUFFER_FILL_THRESHOLD = 50;
        private readonly Queue<String> _fileBuffer = new Queue<String>();
        private readonly String _rootDirectory;
        private volatile Boolean _isRunning;
        private volatile Boolean _recursiveCrawling;

        private Thread _thread;

        public Boolean IsRunning { get => _isRunning; private set => _isRunning = value; }

        public Crawler(String rootDirectory, Boolean recursiveCrawling)
        {
            _rootDirectory = rootDirectory;
            _recursiveCrawling = recursiveCrawling;
        }

        public String GetNextFile()
        {
            while (true)
            {
                Boolean doSleep;
                lock (_fileBuffer)
                {
                    doSleep = !_fileBuffer.Any();
                }
                if (doSleep)
                {
                    Thread.Sleep(BUFFER_EMPTY_SLEEP);
                }
                else
                {
                    break;
                }
            }

            String nextFile;
            lock (_fileBuffer)
            {
                nextFile = _fileBuffer.Dequeue();
            }

            return nextFile;
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

            List<String> files = Directory.GetFiles(directory).ToList();

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
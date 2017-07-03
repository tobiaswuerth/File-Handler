namespace ch.wuerth.tobias.filehandler.Executable
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using Core.Enums;
    using Core.ValueObjects;
    using Logger;
    using Plugin;

    #endregion

    public partial class FormThreadManager : Form
    {
        private const Int32 UI_UPDATE_INTERVAL = 100; // ms
        private const Int32 CRAWL_DONE_WAIT_THREADS_END = 500; // ms
        private volatile FileLogger _logger = new FileLogger();
        private readonly Int32 _numberOfThreads;
        private readonly Boolean _recursive;
        private readonly String _rootDirectory;
        private readonly List<PluginWorker> _threads = new List<PluginWorker>();
        private volatile Crawler _crawler;
        private volatile String _lastFile = String.Empty;
        private volatile List<PluginBase> _plugins;
        private Boolean _uiThreadRunning = true;
        private Thread _uiUpdateThread;

        ~FormThreadManager()
        {
            _logger.Dispose();
        }
        public FormThreadManager(String rootDirectory, List<PluginBase> plugins, Int32 numberOfThreads, Boolean recursive)
        {
            InitializeComponent();

            _rootDirectory = rootDirectory;
            _plugins = plugins;
            _numberOfThreads = numberOfThreads;
            _recursive = recursive;

            _plugins.ForEach(x =>
                             {
                                 x.Logger = _logger;
                                 x.OnStart += () => _logger.Log(new LogEntry($"{x.Name}", "Plugin started", LogType.Information));
                                 x.OnFinish += () => _logger.Log(new LogEntry($"{x.Name}", "Plugin finished", LogType.Information));
                                 x.OnError += message => _logger.Log(new LogEntry($"{x.Name}", message, LogType.Error));
                                 x.OnWarning += message => _logger.Log(new LogEntry($"{x.Name}", message, LogType.Warning));
                             });

            lblRootDirectory.Text = $"Root directory: {rootDirectory}";
            lblThreads.Text = $"Threads: {numberOfThreads}";
        }

        private (String, PluginBase) GetNextFile()
        {
            if (_crawler.IsDone)
            {
                return (null, null);
            }

            String file = _crawler.GetNextFile();
            _lastFile = file;
            String extension = Path.GetExtension(file);
            PluginBase plugin = _plugins.FirstOrDefault(x => x.Extensions.Contains(extension));
            return (file, plugin);
        }

        private void btnStop_Click(Object sender, EventArgs e)
        {
            _crawler.Stop();
            _threads.ForEach(x => x.Stop());
            btnStop.Text = "Stopping...";
            btnStop.Enabled = false;
            while (_crawler.IsRunning || _threads.Any(x => x.IsRunning))
            {
                Thread.Sleep(250);
            }

            btnStop.Text = "Stopped";
            pbRunning.Style = ProgressBarStyle.Continuous;
            btnStart.Enabled = true;
        }

        private void FormThreadManager_Load(Object sender, EventArgs e)
        {
            // init crawling thread
            _crawler = new Crawler(_rootDirectory, _recursive, _logger);
            _crawler.OnDone += () =>
                               {
                                   // wait for every worker to be done
                                   while (_threads.Any(x => x.IsWorking))
                                   {
                                       Thread.Sleep(CRAWL_DONE_WAIT_THREADS_END);
                                   }

                                   btnStop.Invoke((MethodInvoker) delegate
                                                                  {
                                                                      btnStop_Click(btnStop, EventArgs.Empty);
                                                                      lblTimeStopped.Text = $"Time stopped: {DateTime.Now:T}";
                                                                      btnStop.Enabled = false;
                                                                      btnStart.Enabled = true;
                                                                  });
                               };

            // init file handling numberOfThreads
            for (Int32 i = 0; i < _numberOfThreads; i++)
            {
                _threads.Add(new PluginWorker(GetNextFile, _logger));
            }

            // init ui thread
            _uiUpdateThread = new Thread(UiUpdate);
            _uiUpdateThread.Start();
        }

        private void UiUpdate()
        {
            try
            {
                while (_uiThreadRunning)
                {
                    lblLastFile.Invoke((MethodInvoker)delegate
                                                      {
                                                          lblLastFile.Text = $"Last file: {_lastFile}";
                                                      });
                    lbxThreads.Invoke((MethodInvoker)delegate
                                                      {
                                                          lbxThreads.Items.Clear();
                                                          _threads.ForEach(x => lbxThreads.Items.Add($"Thread[{x.ThreadId}]: {x.IsRunning}"));
                                                      });
                    Thread.Sleep(UI_UPDATE_INTERVAL);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void cbxWarning_CheckedChanged(Object sender, EventArgs e)
        {
            _logger.LogWarnings = cbxWarning.Checked;
        }

        private void cbxError_CheckedChanged(Object sender, EventArgs e)
        {
            _logger.LogErrors = cbxError.Checked;
        }

        private void cbxInformation_CheckedChanged(Object sender, EventArgs e)
        {
            _logger.LogInformations = cbxInformation.Checked;
        }

        private void FormThreadManager_FormClosing(Object sender, FormClosingEventArgs e)
        {
            btnStop_Click(btnStop, EventArgs.Empty);
            _uiThreadRunning = false;
            _logger.Dispose();
        }

        private void btnStart_Click(Object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            lblTimeStarted.Text = $"Time started: {DateTime.Now.ToLongTimeString()}";
            lblTimeStopped.Text = "Time stopped: -";
            lblLastFile.Text = "Last file: -";
            pbRunning.Style = ProgressBarStyle.Marquee;

            _crawler.Start();
            _threads.ForEach(x => x.Start());

            btnStop.Enabled = true;
        }
    }
}
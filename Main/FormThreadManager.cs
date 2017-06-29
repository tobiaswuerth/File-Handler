namespace ch.wuerth.tobias.filehandler.Main
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using Plugin;

    #endregion

    public partial class FormThreadManager : Form
    {
        private readonly Int32 _amountOfThreads;
        private readonly Boolean _recursive;
        private readonly String _rootDirectory;
        private readonly List<PluginWorker> _threads = new List<PluginWorker>();
        private volatile Crawler _crawler;
        private volatile List<PluginBase> _plugins;

        public FormThreadManager(String rootDirectory, List<PluginBase> plugins, Int32 amountOfThreads, Boolean recursive)
        {
            InitializeComponent();
            _rootDirectory = rootDirectory;
            _plugins = plugins;
            _amountOfThreads = amountOfThreads;
            _recursive = recursive;
        }

        protected (String, PluginBase) GetNextFile()
        {
            if (!_crawler.IsRunning)
            {
                return (null, null);
            }

            String file = _crawler.GetNextFile();
            String extension = Path.GetExtension(file);
            PluginBase plugin = _plugins.FirstOrDefault(x => x.Extensions.Contains(extension));
            return (file, plugin);
        }

        private void Log(String message, PluginWorker worker)
        {
            lbLog.Invoke((MethodInvoker) delegate
                                         {
                                             ListViewItem i = new ListViewItem();
                                             i.ForeColor = Color.Red;
                                             i.
                                             lbLog.Items.Add(message);
                                             Int32 visibleItems = lbLog.ClientSize.Height / lbLog.ItemHeight;
                                             lbLog.TopIndex = Math.Max(lbLog.Items.Count - visibleItems + 1, 0);
                                             Application.DoEvents();
                                         });
        }

        private void btnStop_Click(Object sender, EventArgs e)
        {
            _crawler.Stop();
            _threads.ForEach(x => x.Stop());
        }

        private void FormThreadManager_Load(Object sender, EventArgs e)
        {
            // init crawling thread
            _crawler = new Crawler(_rootDirectory, _recursive);
            _crawler.Start();

            // init file handling amountOfThreads
            for (Int32 i = 0; i < _amountOfThreads; i++)
            {
                _threads.Add(new PluginWorker(GetNextFile, Log));
            }

            _threads.ForEach(x => x.Start());
        }
    }
}
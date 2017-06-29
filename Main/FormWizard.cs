namespace ch.wuerth.tobias.filehandler.Main
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Core.Enums;
    using Core.Interfaces;
    using Core.ValueObjects;
    using Logger;
    using Plugin;
    using Properties;

    #endregion

    public partial class FormWizard : Form
    {
        private const String PLUGIN_DIRECTORY = "plugins";
        private readonly ILogger _logger = new AlertLogger();

        public FormWizard()
        {
            InitializeComponent();
            InitializeSettings();
            LoadPlugins();
        }

        private void InitializeSettings()
        {
            dgwPlugins.AutoGenerateColumns = false;
        }

        private void ShowError(String body, String head)
        {
            ShowMessageBox(body, head, MessageBoxIcon.Error);
        }

        private void ShowWarning(String body, String head)
        {
            ShowMessageBox(body, head, MessageBoxIcon.Asterisk);
        }

        private void ShowNotice(String body, String head)
        {
            ShowMessageBox(body, head, MessageBoxIcon.Information);
        }

        private void ShowMessageBox(String body, String head, MessageBoxIcon ico)
        {
            MessageBox.Show(this, body, head, MessageBoxButtons.OK, ico);
        }

        private void LoadPlugins()
        {
            if (!Directory.Exists(PLUGIN_DIRECTORY))
            {
                ShowWarning(Resources.hint_body_no_plugin_folder, Resources.hint_head_no_plugin_folder);
                Directory.CreateDirectory(PLUGIN_DIRECTORY);
            }
            String[] files = Directory.GetFiles(PLUGIN_DIRECTORY);
            List<PluginBase> plugins = new List<PluginBase>();
            foreach (String file in files.Where(x => x.EndsWith(".dll")))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(file);
                List<Type> ts = pluginAssembly.GetTypes().Where(x => typeof(PluginBase).IsAssignableFrom(x)).ToList();
                ts.ForEach(x => plugins.Add((PluginBase) Activator.CreateInstance(x)));
            }

            if (!plugins.Any())
            {
                ShowWarning(Resources.hint_body_no_plugin_found, Resources.hint_head_no_plugin_found);
            }
            dgwPlugins.DataSource = plugins;
        }

        private void btnClose_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void btnChooseDirectory_Click_1(Object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = Resources.FormMain_FolderBrowserDialog_Description;
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = txtDirectoryPath.Text.Trim();
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    txtDirectoryPath.Text = dialog.SelectedPath.Trim();
                }
            }
        }

        private void btnStart_Click(Object sender, EventArgs e)
        {
            String directory = txtDirectoryPath.Text.Trim();
            if (String.IsNullOrEmpty(directory))
            {
                ShowError(Resources.hint_body_no_root_directory, Resources.hint_body_no_root_directory);
                return;
            }

            List<PluginBase> selectedPlugins = new List<PluginBase>();
            foreach (DataGridViewRow row in dgwPlugins.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell) row.Cells[0];
                if (cell.Value != cell.TrueValue)
                {
                    continue;
                }

                PluginBase item = (PluginBase) row.DataBoundItem;
                selectedPlugins.Add(item);
            }

            if (!selectedPlugins.Any())
            {
                ShowError(Resources.hint_body_no_plugin_selected, Resources.hint_head_no_plugin_selected);
                return;
            }

            // contains duplicates
            if (selectedPlugins.Any(x => x.Extensions.Any(y => selectedPlugins.Where(h => !h.Guid.Equals(x.Guid)).Any(h => h.Extensions.Contains(y)))))
            {
                ShowError(Resources.hint_body_ambiguous_plugin, Resources.hint_head_ambiguous_plugin);
                return;
            }

            Hide();
            new FormThreadManager(directory, selectedPlugins, Int32.Parse(nudThreads.Value.ToString()), cbxDirectoriesRecursively.Checked).ShowDialog();
            Close();
        }

        private void dgwPlugins_CellMouseUp(Object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != ColumnEnablePlugin.Index || e.RowIndex == -1)
            {
                return;
            }

            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell) dgwPlugins[ColumnEnablePlugin.Index, e.RowIndex];
            if (cell.Value != cell.TrueValue)
            {
                return;
            }

            // checked
            DataGridViewRow row = dgwPlugins.Rows[e.RowIndex];
            PluginBase plugin = (PluginBase) row.DataBoundItem;
            plugin.Logger = _logger;
            plugin.OnInitError += message =>
                                  {
                                      _logger.Log(new LogEntry(plugin.Name, message, LogType.Error));
                                      cell.Value = cell.FalseValue;
                                  };
            plugin.OnInitSuccess += () => _logger.Log(new LogEntry(plugin.Name, "Plugin successfully initialized", LogType.Information));
            plugin.Initialize();
        }

        private void dgwPlugins_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnEnablePlugin.Index && e.RowIndex != -1)
            {
                dgwPlugins.EndEdit();
            }
        }

        private void dgwPlugins_CellFormatting(Object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColumnExtensions.Index && e.RowIndex != -1 && null != e.Value)
            {
                List<String> extensions = e.Value as List<String> ?? new List<String>();
                e.Value = extensions.Any() ? extensions.Aggregate((a, b) => $"*.{a}, *.{b}") : "";
                e.FormattingApplied = true;
            }
        }
    }
}
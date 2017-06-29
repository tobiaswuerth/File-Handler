namespace ch.wuerth.tobias.filehandler.PluginRemoveFiles
{
    using System;
    using System.Windows.Forms;
    using Enums;
    using ValueObjects;

    public partial class FormExtensions : Form
    {
        private readonly DataBridge _bridge;

        public FormExtensions(DataBridge bridge)
        {
            InitializeComponent();
            _bridge = bridge;
        }

        private void btnCancel_Click(Object sender, EventArgs e)
        {
            if (lbEntries.Items.Count > 0)
            {
                if (MessageBox.Show(this, "Are you sure you want to cancel the configuration? All changes will be lost.", "Cancel Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            _bridge.Status = Status.Canceled;
            _bridge.Extensions.Clear();
            Close();
        }

        private void btnAdd_Click(Object sender, EventArgs e)
        {
            String extension = txtAdd.Text.Trim().ToLower();
            if (!extension.StartsWith(".") || extension.Length < 2)
            {
                MessageBox.Show(this, "The extension is not in a valid format. Try '.<extension>' - e.g. '.txt', '.jpg' or '.png'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbEntries.Items.Add(extension);
            txtAdd.Text = String.Empty;
            txtAdd.Focus();
        }

        private void btnRemove_Click(Object sender, EventArgs e)
        {
            if (lbEntries.SelectedIndex < 0)
            {
                MessageBox.Show(this, "No entry selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbEntries.Items.RemoveAt(lbEntries.SelectedIndex);
        }

        private void btnSaveAndClose_Click(Object sender, EventArgs e)
        {
            _bridge.Extensions.Clear();
            foreach (String i in lbEntries.Items)
            {
                _bridge.Extensions.Add(i);
            }

            _bridge.Status = Status.Saved;
            Close();
        }
    }
}
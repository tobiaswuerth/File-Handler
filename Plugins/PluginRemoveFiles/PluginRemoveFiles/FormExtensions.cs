namespace ch.wuerth.tobias.filehandler.PluginRemoveFiles
{
    #region usings

    using System;
    using System.Windows.Forms;

    using Enums;

    using ValueObjects;

    #endregion

    public partial class FormExtensions : Form
    {
        private readonly DataBridge _db;

        public FormExtensions(DataBridge db)
        {
            InitializeComponent();
            _db = db;
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

            _db.Status = Status.Canceled;
            _db.Extensions.Clear();
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
            _db.Extensions.Clear();
            foreach (String i in lbEntries.Items)
            {
                _db.Extensions.Add(i);
            }

            _db.Status = Status.Saved;
            Close();
        }

        private void FormExtensions_Load(Object sender, EventArgs e)
        {
            ActiveControl = txtAdd;

            _db.Extensions.ForEach(x => lbEntries.Items.Add(x));
        }
    }
}
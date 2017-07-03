namespace ch.wuerth.tobias.filehandler.PluginUnzip
{
    #region usings

    using System;
    using System.Windows.Forms;

    using Enum;

    using ValueObjects;

    #endregion

    public partial class FormConfiguration : Form
    {
        private readonly DataBridge _db;

        public FormConfiguration(DataBridge db)
        {
            InitializeComponent();
            _db = db;
        }

        private void btnSaveAndClose_Click(Object sender, EventArgs e)
        {
            _db.CreateSubdir = cbxCreateSubdir.Checked;
            _db.DeleteArchive = cbxDeleteArchive.Checked;
            _db.Status = Status.Saved;
            Close();
        }

        private void btnCancel_Click(Object sender, EventArgs e)
        {
            _db.Status = Status.Canceled;
            Close();
        }

        private void FormConfiguration_Load(Object sender, EventArgs e)
        {
            if (_db.CreateSubdir.HasValue)
            {
                cbxCreateSubdir.Checked = _db.CreateSubdir.Value;
            }
            if (_db.DeleteArchive.HasValue)
            {
                cbxDeleteArchive.Checked = _db.DeleteArchive.Value;
            }
        }
    }
}
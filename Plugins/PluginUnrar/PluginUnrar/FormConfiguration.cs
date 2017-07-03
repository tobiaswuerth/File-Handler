namespace PluginUnrar
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Enums;
    using ValueObjects;

    public partial class FormConfiguration : Form
    {
        private const String EXE_UNRAR_FILENAME = "unrar.exe";
        private readonly DataBridge _db;

        public FormConfiguration(DataBridge db)
        {
            _db = db;
            InitializeComponent();

            txtWinrarDirectory.Text = _db.WinrarDirectory ?? String.Empty;
            if (_db.CreateSubdirectory.HasValue)
            {
                cbxCreateSubdir.Checked = _db.CreateSubdirectory.Value;
            }
            if (_db.DeleteArchiveAfterExtraction.HasValue)
            {
                cbxDeleteArchive.Checked = _db.DeleteArchiveAfterExtraction.Value;
            }
            if (_db.UsePasswords.HasValue)
            {
                cbxUsePassword.Checked = _db.UsePasswords.Value;
            }
            _db.Passwords?.ForEach(x => lbPasswords.Items.Add(x));
        }

        private void btnOpenWinrarDirectory_Click(Object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the root directory of the WinRAR installation";
                fbd.SelectedPath = _db.WinrarDirectory ?? String.Empty;
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    String dir = fbd.SelectedPath;
                    if (!File.Exists(Path.Combine(dir, EXE_UNRAR_FILENAME)))
                    {
                        MessageBox.Show(this, $"File '{EXE_UNRAR_FILENAME}' not found in given directory. Please select a different directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnOpenWinrarDirectory_Click(btnOpenWinrarDirectory, EventArgs.Empty);
                        return;
                    }

                    _db.WinrarExe = Directory.GetFiles(dir).First(x => Path.GetFileName(x).ToLower().Equals(EXE_UNRAR_FILENAME));
                    
                    txtWinrarDirectory.Text = dir.Trim();
                }
            }
        }

        private void cbxUsePassword_CheckedChanged(Object sender, EventArgs e)
        {
            Boolean cs = cbxUsePassword.Checked;
            lbPasswords.Enabled = cs;
            txtPassword.Enabled = cs;
            btnAddPassword.Enabled = cs;
            btnRemovePassword.Enabled = cs;
            btnImport.Enabled = cs;
            btnClear.Enabled = cs;
        }

        private void btnAddPassword_Click(Object sender, EventArgs e)
        {
            String pass = txtPassword.Text;
            if (String.IsNullOrEmpty(pass))
            {
                MessageBox.Show(this, "An empty password will be treatet as no password", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (pass.Contains("\""))
            {
                MessageBox.Show(this, "The given password must not contain '\"'.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbPasswords.Items.Add(pass);
            txtPassword.Text = String.Empty;
            txtPassword.Focus();
        }

        private void btnRemovePassword_Click(Object sender, EventArgs e)
        {
            if (0 > lbPasswords.SelectedIndex)
            {
                MessageBox.Show(this, "No password selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbPasswords.Items.RemoveAt(lbPasswords.SelectedIndex);
        }

        private void btnCancel_Click(Object sender, EventArgs e)
        {
            _db.Status = Status.Canceled;
            Close();
        }

        private void btnSave_Click(Object sender, EventArgs e)
        {
            _db.WinrarDirectory = txtWinrarDirectory.Text;
            _db.CreateSubdirectory = cbxCreateSubdir.Checked;
            _db.DeleteArchiveAfterExtraction = cbxDeleteArchive.Checked;
            _db.UsePasswords = cbxUsePassword.Checked;
            _db.Passwords = new List<String>();
            foreach (String pass in lbPasswords.Items)
            {
                _db.Passwords.Add(pass);
            }

            if (_db.UsePasswords.Value && !_db.Passwords.Any())
            {
                MessageBox.Show(this, "At least one password has to be provided", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _db.Status = Status.Saved;
            Close();
        }

        private void btnImport_Click(Object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;
                ofd.CheckPathExists = true;
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                using (Stream s = ofd.OpenFile())
                {
                    using (StreamReader rs = new StreamReader(s))
                    {
                        String line;
                        while ((line = rs.ReadLine()) != null)
                        {
                            lbPasswords.Items.Add(line);
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbPasswords.Items.Clear();
        }
    }
}
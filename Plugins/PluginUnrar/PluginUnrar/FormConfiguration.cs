using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginUnrar
{
    using System.IO;

    using ch.wuerth.tobias.filehandler.PluginUnzip.Enum;

    using ValueObjects;

    public partial class FormConfiguration : Form
    {
        private const String EXE_UNRAR_FILENAME = "unrar.exe";
        private DataBridge _db;

        public FormConfiguration(DataBridge db)
        {
            _db = db;
            InitializeComponent();
        }

        private void btnOpenWinrarDirectory_Click(object sender, EventArgs e)
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
                        MessageBox.Show(this, $"File '{EXE_UNRAR_FILENAME}' not found in given directory. Please select a different directory.");
                        btnOpenWinrarDirectory_Click(btnOpenWinrarDirectory, EventArgs.Empty);
                        return;
                    }

                    txtWinrarDirectory.Text = dir.Trim();
                }
            }
        }

        private void cbxUsePassword_CheckedChanged(object sender, EventArgs e)
        {
            Boolean cs = cbxUsePassword.Checked;
            lbPasswords.Enabled = cs;
            txtPassword.Enabled = cs;
            btnAddPassword.Enabled = cs;
            btnRemovePassword.Enabled = cs;
        }

        private void btnAddPassword_Click(object sender, EventArgs e)
        {
            lbPasswords.Items.Add(txtPassword.Text);
        }

        private void btnRemovePassword_Click(object sender, EventArgs e)
        {
            if (0 > lbPasswords.SelectedIndex)
            {
                MessageBox.Show(this, "No password selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbPasswords.Items.RemoveAt(lbPasswords.SelectedIndex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _db.Status = Status.Canceled;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _db.WinrarDirectory = txtWinrarDirectory.Text;
            _db.CreateSubdirectory = cbxCreateSubdir.Checked;
            // todo
        }
    }
}

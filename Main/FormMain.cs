namespace ch.wuerth.tobias.filehandler.Main
{
    #region usings

    using System;
    using System.Windows.Forms;

    using Properties;

    #endregion

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void btnChooseDirectory_Click_1(object sender, EventArgs e)
        {

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = Resources.FormMain_FolderBrowserDialog_Description;
                dialog.ShowNewFolderButton = true;
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    txtDirectoryPath.Text = dialog.SelectedPath.Trim();
                }
            }
        }
    }
}
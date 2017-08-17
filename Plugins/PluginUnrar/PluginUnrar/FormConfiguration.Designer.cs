namespace PluginUnrar
{
    partial class FormConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenWinrarDirectory = new System.Windows.Forms.Button();
            this.txtWinrarDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPasswords = new System.Windows.Forms.ListBox();
            this.cbxCreateSubdir = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDeleteArchive = new System.Windows.Forms.CheckBox();
            this.cbxUsePassword = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAddPassword = new System.Windows.Forms.Button();
            this.btnRemovePassword = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenWinrarDirectory
            // 
            this.btnOpenWinrarDirectory.Location = new System.Drawing.Point(428, 48);
            this.btnOpenWinrarDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenWinrarDirectory.Name = "btnOpenWinrarDirectory";
            this.btnOpenWinrarDirectory.Size = new System.Drawing.Size(124, 38);
            this.btnOpenWinrarDirectory.TabIndex = 0;
            this.btnOpenWinrarDirectory.Text = "...";
            this.btnOpenWinrarDirectory.UseVisualStyleBackColor = true;
            this.btnOpenWinrarDirectory.Click += new System.EventHandler(this.btnOpenWinrarDirectory_Click);
            // 
            // txtWinrarDirectory
            // 
            this.txtWinrarDirectory.Location = new System.Drawing.Point(16, 48);
            this.txtWinrarDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWinrarDirectory.Name = "txtWinrarDirectory";
            this.txtWinrarDirectory.ReadOnly = true;
            this.txtWinrarDirectory.Size = new System.Drawing.Size(400, 31);
            this.txtWinrarDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path to WinRAR installation directory";
            // 
            // lbPasswords
            // 
            this.lbPasswords.Enabled = false;
            this.lbPasswords.FormattingEnabled = true;
            this.lbPasswords.ItemHeight = 25;
            this.lbPasswords.Location = new System.Drawing.Point(16, 302);
            this.lbPasswords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbPasswords.Name = "lbPasswords";
            this.lbPasswords.Size = new System.Drawing.Size(400, 129);
            this.lbPasswords.TabIndex = 3;
            // 
            // cbxCreateSubdir
            // 
            this.cbxCreateSubdir.AutoSize = true;
            this.cbxCreateSubdir.Checked = true;
            this.cbxCreateSubdir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCreateSubdir.Location = new System.Drawing.Point(16, 137);
            this.cbxCreateSubdir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxCreateSubdir.Name = "cbxCreateSubdir";
            this.cbxCreateSubdir.Size = new System.Drawing.Size(392, 29);
            this.cbxCreateSubdir.TabIndex = 4;
            this.cbxCreateSubdir.Text = "Create subdirectory for each archive";
            this.cbxCreateSubdir.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Settings";
            // 
            // cbxDeleteArchive
            // 
            this.cbxDeleteArchive.AutoSize = true;
            this.cbxDeleteArchive.Checked = true;
            this.cbxDeleteArchive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDeleteArchive.Location = new System.Drawing.Point(16, 171);
            this.cbxDeleteArchive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxDeleteArchive.Name = "cbxDeleteArchive";
            this.cbxDeleteArchive.Size = new System.Drawing.Size(439, 29);
            this.cbxDeleteArchive.TabIndex = 6;
            this.cbxDeleteArchive.Text = "Delete archive after successful extraction";
            this.cbxDeleteArchive.UseVisualStyleBackColor = true;
            // 
            // cbxUsePassword
            // 
            this.cbxUsePassword.AutoSize = true;
            this.cbxUsePassword.Location = new System.Drawing.Point(16, 206);
            this.cbxUsePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxUsePassword.Name = "cbxUsePassword";
            this.cbxUsePassword.Size = new System.Drawing.Size(191, 29);
            this.cbxUsePassword.TabIndex = 7;
            this.cbxUsePassword.Text = "Use passwords";
            this.cbxUsePassword.UseVisualStyleBackColor = true;
            this.cbxUsePassword.CheckedChanged += new System.EventHandler(this.cbxUsePassword_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 273);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Passwords:";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(16, 440);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(400, 31);
            this.txtPassword.TabIndex = 10;
            // 
            // btnAddPassword
            // 
            this.btnAddPassword.Enabled = false;
            this.btnAddPassword.Location = new System.Drawing.Point(428, 440);
            this.btnAddPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPassword.Name = "btnAddPassword";
            this.btnAddPassword.Size = new System.Drawing.Size(124, 38);
            this.btnAddPassword.TabIndex = 9;
            this.btnAddPassword.Text = "Add";
            this.btnAddPassword.UseVisualStyleBackColor = true;
            this.btnAddPassword.Click += new System.EventHandler(this.btnAddPassword_Click);
            // 
            // btnRemovePassword
            // 
            this.btnRemovePassword.Enabled = false;
            this.btnRemovePassword.Location = new System.Drawing.Point(428, 302);
            this.btnRemovePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemovePassword.Name = "btnRemovePassword";
            this.btnRemovePassword.Size = new System.Drawing.Size(124, 38);
            this.btnRemovePassword.TabIndex = 11;
            this.btnRemovePassword.Text = "Remove";
            this.btnRemovePassword.UseVisualStyleBackColor = true;
            this.btnRemovePassword.Click += new System.EventHandler(this.btnRemovePassword_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 544);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(404, 38);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(428, 544);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 38);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(428, 394);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(124, 38);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(428, 348);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(124, 38);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormConfiguration
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(577, 601);
            this.ControlBox = false;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemovePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnAddPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxUsePassword);
            this.Controls.Add(this.cbxDeleteArchive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCreateSubdir);
            this.Controls.Add(this.lbPasswords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWinrarDirectory);
            this.Controls.Add(this.btnOpenWinrarDirectory);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguration";
            this.ShowIcon = false;
            this.Text = "UnRar Plugin Configuration";
            this.Load += new System.EventHandler(this.FormConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenWinrarDirectory;
        private System.Windows.Forms.TextBox txtWinrarDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbPasswords;
        private System.Windows.Forms.CheckBox cbxCreateSubdir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxDeleteArchive;
        private System.Windows.Forms.CheckBox cbxUsePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAddPassword;
        private System.Windows.Forms.Button btnRemovePassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClear;
    }
}
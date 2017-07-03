namespace ch.wuerth.tobias.filehandler.PluginUnzip
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
            this.cbxCreateSubdir = new System.Windows.Forms.CheckBox();
            this.cbxDeleteArchive = new System.Windows.Forms.CheckBox();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxCreateSubdir
            // 
            this.cbxCreateSubdir.AutoSize = true;
            this.cbxCreateSubdir.Checked = true;
            this.cbxCreateSubdir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCreateSubdir.Location = new System.Drawing.Point(12, 12);
            this.cbxCreateSubdir.Name = "cbxCreateSubdir";
            this.cbxCreateSubdir.Size = new System.Drawing.Size(350, 29);
            this.cbxCreateSubdir.TabIndex = 0;
            this.cbxCreateSubdir.Text = "Create subdirectory for each file";
            this.cbxCreateSubdir.UseVisualStyleBackColor = true;
            // 
            // cbxDeleteArchive
            // 
            this.cbxDeleteArchive.AutoSize = true;
            this.cbxDeleteArchive.Checked = true;
            this.cbxDeleteArchive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDeleteArchive.Location = new System.Drawing.Point(12, 47);
            this.cbxDeleteArchive.Name = "cbxDeleteArchive";
            this.cbxDeleteArchive.Size = new System.Drawing.Size(397, 29);
            this.cbxDeleteArchive.TabIndex = 1;
            this.cbxDeleteArchive.Text = "Delete file after successful extraction";
            this.cbxDeleteArchive.UseVisualStyleBackColor = true;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(15, 101);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(318, 44);
            this.btnSaveAndClose.TabIndex = 5;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 101);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 44);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormConfiguration
            // 
            this.AcceptButton = this.btnSaveAndClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(515, 169);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.cbxDeleteArchive);
            this.Controls.Add(this.cbxCreateSubdir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguration";
            this.ShowIcon = false;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.FormConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxCreateSubdir;
        private System.Windows.Forms.CheckBox cbxDeleteArchive;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
    }
}
namespace ch.wuerth.tobias.filehandler.PluginRemoveFiles
{
    partial class FormExtensions
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbEntries = new System.Windows.Forms.ListBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(466, 17);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 44);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(466, 73);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(150, 44);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbEntries
            // 
            this.lbEntries.FormattingEnabled = true;
            this.lbEntries.ItemHeight = 25;
            this.lbEntries.Location = new System.Drawing.Point(24, 73);
            this.lbEntries.Margin = new System.Windows.Forms.Padding(6);
            this.lbEntries.Name = "lbEntries";
            this.lbEntries.Size = new System.Drawing.Size(426, 229);
            this.lbEntries.TabIndex = 2;
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(24, 23);
            this.txtAdd.Margin = new System.Windows.Forms.Padding(6);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(426, 31);
            this.txtAdd.TabIndex = 3;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(24, 342);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(430, 44);
            this.btnSaveAndClose.TabIndex = 4;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(466, 342);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 44);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormExtensions
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(632, 410);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.lbEntries);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExtensions";
            this.ShowIcon = false;
            this.Text = "Configure Extensions";
            this.Load += new System.EventHandler(this.FormExtensions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbEntries;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
    }
}
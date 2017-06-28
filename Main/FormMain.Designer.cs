namespace ch.wuerth.tobias.filehandler.Main
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgwPlugins = new System.Windows.Forms.DataGridView();
            this.ColumnEnablePlugin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExtensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVersionMajor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVersionMinor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDirectoriesRecursively = new System.Windows.Forms.CheckBox();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPlugins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Choose root directory";
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirectoryPath.Location = new System.Drawing.Point(16, 36);
            this.txtDirectoryPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.ReadOnly = true;
            this.txtDirectoryPath.Size = new System.Drawing.Size(1072, 31);
            this.txtDirectoryPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Select plugins";
            // 
            // dgwPlugins
            // 
            this.dgwPlugins.AllowUserToAddRows = false;
            this.dgwPlugins.AllowUserToDeleteRows = false;
            this.dgwPlugins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwPlugins.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwPlugins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPlugins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEnablePlugin,
            this.ColumnName,
            this.ColumnDescription,
            this.ColumnExtensions,
            this.ColumnVersionMajor,
            this.ColumnVersionMinor});
            this.dgwPlugins.Location = new System.Drawing.Point(16, 108);
            this.dgwPlugins.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgwPlugins.Name = "dgwPlugins";
            this.dgwPlugins.ReadOnly = true;
            this.dgwPlugins.RowTemplate.Height = 33;
            this.dgwPlugins.Size = new System.Drawing.Size(1275, 224);
            this.dgwPlugins.TabIndex = 4;
            // 
            // ColumnEnablePlugin
            // 
            this.ColumnEnablePlugin.HeaderText = "Enabled";
            this.ColumnEnablePlugin.Name = "ColumnEnablePlugin";
            this.ColumnEnablePlugin.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            // 
            // ColumnExtensions
            // 
            this.ColumnExtensions.HeaderText = "Extension";
            this.ColumnExtensions.Name = "ColumnExtensions";
            this.ColumnExtensions.ReadOnly = true;
            // 
            // ColumnVersionMajor
            // 
            this.ColumnVersionMajor.HeaderText = "Major Version";
            this.ColumnVersionMajor.Name = "ColumnVersionMajor";
            this.ColumnVersionMajor.ReadOnly = true;
            // 
            // ColumnVersionMinor
            // 
            this.ColumnVersionMinor.HeaderText = "Minor Version";
            this.ColumnVersionMinor.Name = "ColumnVersionMinor";
            this.ColumnVersionMinor.ReadOnly = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(887, 453);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 30);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1092, 453);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 344);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "3. Options";
            // 
            // cbxDirectoriesRecursively
            // 
            this.cbxDirectoriesRecursively.AutoSize = true;
            this.cbxDirectoriesRecursively.Checked = true;
            this.cbxDirectoriesRecursively.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDirectoriesRecursively.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDirectoriesRecursively.Location = new System.Drawing.Point(16, 371);
            this.cbxDirectoriesRecursively.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxDirectoriesRecursively.Name = "cbxDirectoriesRecursively";
            this.cbxDirectoriesRecursively.Size = new System.Drawing.Size(314, 29);
            this.cbxDirectoriesRecursively.TabIndex = 9;
            this.cbxDirectoriesRecursively.Text = "Crawl directories recursively";
            this.cbxDirectoriesRecursively.UseVisualStyleBackColor = true;
            // 
            // nudThreads
            // 
            this.nudThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThreads.Location = new System.Drawing.Point(16, 404);
            this.nudThreads.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudThreads.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(70, 31);
            this.nudThreads.TabIndex = 10;
            this.nudThreads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 406);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Threads";
            // 
            // btnChooseDirectory
            // 
            this.btnChooseDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseDirectory.Location = new System.Drawing.Point(1092, 36);
            this.btnChooseDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseDirectory.Name = "btnChooseDirectory";
            this.btnChooseDirectory.Size = new System.Drawing.Size(200, 30);
            this.btnChooseDirectory.TabIndex = 12;
            this.btnChooseDirectory.Text = "...";
            this.btnChooseDirectory.UseVisualStyleBackColor = true;
            this.btnChooseDirectory.Click += new System.EventHandler(this.btnChooseDirectory_Click_1);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 498);
            this.Controls.Add(this.btnChooseDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudThreads);
            this.Controls.Add(this.cbxDirectoriesRecursively);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgwPlugins);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDirectoryPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "File Handler";
            ((System.ComponentModel.ISupportInitialize)(this.dgwPlugins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgwPlugins;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxDirectoriesRecursively;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnEnablePlugin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtensions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVersionMajor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVersionMinor;
        private System.Windows.Forms.Button btnChooseDirectory;
    }
}


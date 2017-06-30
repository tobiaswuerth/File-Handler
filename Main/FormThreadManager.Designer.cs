﻿namespace ch.wuerth.tobias.filehandler.Main
{
    partial class FormThreadManager
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
            this.lblThreads = new System.Windows.Forms.Label();
            this.lblRootDirectory = new System.Windows.Forms.Label();
            this.lblTimeStarted = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxInformation = new System.Windows.Forms.CheckBox();
            this.cbxWarning = new System.Windows.Forms.CheckBox();
            this.cbxError = new System.Windows.Forms.CheckBox();
            this.pbRunning = new System.Windows.Forms.ProgressBar();
            this.lblLastFile = new System.Windows.Forms.Label();
            this.lblTimeStopped = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Location = new System.Drawing.Point(12, 19);
            this.lblThreads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(110, 25);
            this.lblThreads.TabIndex = 0;
            this.lblThreads.Text = "Threads: -";
            // 
            // lblRootDirectory
            // 
            this.lblRootDirectory.AutoSize = true;
            this.lblRootDirectory.Location = new System.Drawing.Point(12, 54);
            this.lblRootDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRootDirectory.Name = "lblRootDirectory";
            this.lblRootDirectory.Size = new System.Drawing.Size(165, 25);
            this.lblRootDirectory.TabIndex = 3;
            this.lblRootDirectory.Text = "Root directory: -";
            // 
            // lblTimeStarted
            // 
            this.lblTimeStarted.AutoSize = true;
            this.lblTimeStarted.Location = new System.Drawing.Point(12, 90);
            this.lblTimeStarted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeStarted.Name = "lblTimeStarted";
            this.lblTimeStarted.Size = new System.Drawing.Size(150, 25);
            this.lblTimeStarted.TabIndex = 4;
            this.lblTimeStarted.Text = "Time started: -";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(13, 584);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(625, 54);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Log the following events:";
            // 
            // cbxInformation
            // 
            this.cbxInformation.AutoSize = true;
            this.cbxInformation.Location = new System.Drawing.Point(17, 245);
            this.cbxInformation.Margin = new System.Windows.Forms.Padding(6);
            this.cbxInformation.Name = "cbxInformation";
            this.cbxInformation.Size = new System.Drawing.Size(150, 29);
            this.cbxInformation.TabIndex = 10;
            this.cbxInformation.Text = "Information";
            this.cbxInformation.UseVisualStyleBackColor = true;
            this.cbxInformation.CheckedChanged += new System.EventHandler(this.cbxInformation_CheckedChanged);
            // 
            // cbxWarning
            // 
            this.cbxWarning.AutoSize = true;
            this.cbxWarning.Checked = true;
            this.cbxWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxWarning.Location = new System.Drawing.Point(17, 290);
            this.cbxWarning.Margin = new System.Windows.Forms.Padding(6);
            this.cbxWarning.Name = "cbxWarning";
            this.cbxWarning.Size = new System.Drawing.Size(124, 29);
            this.cbxWarning.TabIndex = 11;
            this.cbxWarning.Text = "Warning";
            this.cbxWarning.UseVisualStyleBackColor = true;
            this.cbxWarning.CheckedChanged += new System.EventHandler(this.cbxWarning_CheckedChanged);
            // 
            // cbxError
            // 
            this.cbxError.AutoSize = true;
            this.cbxError.Checked = true;
            this.cbxError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxError.Location = new System.Drawing.Point(17, 334);
            this.cbxError.Margin = new System.Windows.Forms.Padding(6);
            this.cbxError.Name = "cbxError";
            this.cbxError.Size = new System.Drawing.Size(91, 29);
            this.cbxError.TabIndex = 12;
            this.cbxError.Text = "Error";
            this.cbxError.UseVisualStyleBackColor = true;
            this.cbxError.CheckedChanged += new System.EventHandler(this.cbxError_CheckedChanged);
            // 
            // pbRunning
            // 
            this.pbRunning.Location = new System.Drawing.Point(17, 403);
            this.pbRunning.Margin = new System.Windows.Forms.Padding(6);
            this.pbRunning.Name = "pbRunning";
            this.pbRunning.Size = new System.Drawing.Size(629, 33);
            this.pbRunning.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbRunning.TabIndex = 13;
            // 
            // lblLastFile
            // 
            this.lblLastFile.Location = new System.Drawing.Point(15, 443);
            this.lblLastFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastFile.Name = "lblLastFile";
            this.lblLastFile.Size = new System.Drawing.Size(631, 69);
            this.lblLastFile.TabIndex = 14;
            this.lblLastFile.Text = "Last file: -";
            // 
            // lblTimeStopped
            // 
            this.lblTimeStopped.AutoSize = true;
            this.lblTimeStopped.Location = new System.Drawing.Point(12, 127);
            this.lblTimeStopped.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeStopped.Name = "lblTimeStopped";
            this.lblTimeStopped.Size = new System.Drawing.Size(161, 25);
            this.lblTimeStopped.TabIndex = 15;
            this.lblTimeStopped.Text = "Time stopped: -";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 522);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(625, 54);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormThreadManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 655);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTimeStopped);
            this.Controls.Add(this.lblLastFile);
            this.Controls.Add(this.pbRunning);
            this.Controls.Add(this.cbxError);
            this.Controls.Add(this.cbxWarning);
            this.Controls.Add(this.cbxInformation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblTimeStarted);
            this.Controls.Add(this.lblRootDirectory);
            this.Controls.Add(this.lblThreads);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormThreadManager";
            this.ShowIcon = false;
            this.Text = "Thread Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormThreadManager_FormClosing);
            this.Load += new System.EventHandler(this.FormThreadManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.Label lblRootDirectory;
        private System.Windows.Forms.Label lblTimeStarted;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxInformation;
        private System.Windows.Forms.CheckBox cbxWarning;
        private System.Windows.Forms.CheckBox cbxError;
        private System.Windows.Forms.ProgressBar pbRunning;
        private System.Windows.Forms.Label lblLastFile;
        private System.Windows.Forms.Label lblTimeStopped;
        private System.Windows.Forms.Button btnStart;
    }
}
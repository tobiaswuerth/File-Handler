﻿namespace ch.wuerth.tobias.filehandler.Main
{
    #region usings

    using System;
    using System.Windows.Forms;

    #endregion

    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormWizard());
        }
    }
}
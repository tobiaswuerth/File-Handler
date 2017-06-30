namespace ch.wuerth.tobias.filehandler.PluginUnzip
{
    #region usings

    using System;
    using System.Collections.Generic;

    using filehandler.Plugin;

    #endregion

    public class Plugin : PluginBase
    {
        public Plugin()
        {
            Name = "UnZip";
            Description = "Unzip .zip archives";
            Extensions = new List<String>
                         {
                             ".zip"
                         };
            VersionMajor = 1; // Last changed 2017-06-30 T 1705
            VersionMinor = 1; // Last changed 2017-06-30 T 1705
        }

        public override void Action(String path) { }
    }
}
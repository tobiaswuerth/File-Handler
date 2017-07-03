namespace ch.wuerth.tobias.filehandler.PluginUnzip
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Windows.Forms.VisualStyles;

    using Core.Enums;
    using Core.ValueObjects;

    using Enum;

    using filehandler.Plugin;

    using NUnrar;
    using NUnrar.Archive;

    using PluginUnrar;

    using SharpCompress.Readers;

    using ValueObjects;

    #endregion

    public class Plugin : PluginBase
    {
        private readonly DataBridge _configuration = new DataBridge();
        private readonly String _invalidNameChars;

        public Plugin()
        {
            Name = "UnRar";
            Description = "Unrar .rar archives";
            Extensions = new List<String>
                         {
                             ".rar"
                         };
            VersionMajor = 1; // Last changed 2017-07-03 T 0515
            VersionMinor = 1; // Last changed 2017-07-03 T 0515

            _invalidNameChars = new String(Path.GetInvalidFileNameChars()) + new String(Path.GetInvalidPathChars());
        }

        public override Boolean Initialize()
        {
            IsInitialized = false;

            new FormConfiguration(_configuration).ShowDialog();

            if (_configuration.Status != VisualStyleElement.Status.Saved)
            {
                InitError("Configuration canceled");
                return IsInitialized;
            }

            return base.Initialize();
        }

        public override void Action(String path)
        {
            Start();

            try
            {

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }

            Finish();
        }

        private String NormalizeName(String name)
        {
            _invalidNameChars.ToList().ForEach(x => name = name.Replace(x, '-'));
            return name;
        }
    }
}
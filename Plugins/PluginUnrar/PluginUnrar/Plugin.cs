namespace PluginUnrar
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using ch.wuerth.tobias.filehandler.Core.Enums;
    using ch.wuerth.tobias.filehandler.Core.ValueObjects;
    using ch.wuerth.tobias.filehandler.Plugin;
    using Enums;
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
            if (_configuration.Status != Status.Saved)
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
                String dir = Path.GetDirectoryName(path);
                Process p = new Process
                            {
                                StartInfo =
                                {
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true,
                                    WorkingDirectory = _configuration.WinrarDirectory,
                                    FileName = _configuration.WinrarExe,
                                    CreateNoWindow = true,
                                    Arguments = $"e -ac -ad -ai -cfg- -ep -ibck -kb -or p- -r \"{path}\" \"{dir}\"" 
                                }
                            };

                StreamReader spo = p.StandardOutput;
                StreamReader seo = p.StandardError;

                Log(new LogEntry($"{Name}", $"Starting extraction process for file '{path}'...", LogType.Information));
                p.Start();
                Log(new LogEntry($"{Name}", $"Waiting for the process for file '{path}' to finish...", LogType.Information));
                p.WaitForExit();
                Log(new LogEntry($"{Name}", $"Process for file '{path}' has finished", LogType.Information));

                String line;
                using (spo)
                {
                    while ((line = spo.ReadLine()) != null)
                    {
                        Log(new LogEntry($"{Name} UnRAR output", line, LogType.Information));
                    }
                }
                using (seo)
                {
                    while ((line = seo.ReadLine()) != null)
                    {
                        Log(new LogEntry($"{Name} UnRAR output", line, LogType.Error));
                        Error(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            Finish();
        }
    }
}
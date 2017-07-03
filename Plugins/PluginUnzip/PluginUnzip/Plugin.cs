namespace ch.wuerth.tobias.filehandler.PluginUnzip
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    using Core.Enums;
    using Core.ValueObjects;

    using Enum;

    using filehandler.Plugin;

    using ValueObjects;

    #endregion

    public class Plugin : PluginBase
    {
        private readonly DataBridge _configuration = new DataBridge();
        private readonly String _invalidNameChars;

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
                String directory = Path.GetDirectoryName(path);
                if (null == directory)
                {
                    Error($"Could not extract the parent directory from the file '{path}'");
                    Finish();
                    return;
                }

                if (_configuration.CreateSubdir.Value)
                {
                    String subDir = NormalizeName(Path.GetFileNameWithoutExtension(path));
                    String suffix = String.Empty;

                    while (Directory.Exists(Path.Combine(directory, subDir + suffix)))
                    {
                        suffix = Guid.NewGuid().ToString();
                    }

                    directory = Path.Combine(directory, subDir + suffix);

                    Log(new LogEntry($"{Name}[{Guid}]", $"Creating subdirectory '{subDir}' for file '{path}'...", LogType.Information));
                    Directory.CreateDirectory(directory);
                    Log(new LogEntry($"{Name}[{Guid}]", $"Successfully created subdirectory '{subDir}' for file '{path}'", LogType.Information));
                }

                Log(new LogEntry($"{Name}[{Guid}]", $"Starting extraction for file '{path}'...", LogType.Information));
                ZipFile.ExtractToDirectory(path, directory);
                Log(new LogEntry($"{Name}[{Guid}]", $"Successfully extracted file '{path}'", LogType.Information));

                if (_configuration.DeleteArchive.Value)
                {
                    Log(new LogEntry($"{Name}[{Guid}]", $"Trying to delete file '{path}'...", LogType.Information));
                    File.Delete(path);
                    Log(new LogEntry($"{Name}[{Guid}]", $"Successfully deleted file '{path}'", LogType.Information));
                }
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
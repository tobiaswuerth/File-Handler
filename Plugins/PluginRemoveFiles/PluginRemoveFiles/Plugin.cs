namespace ch.wuerth.tobias.filehandler.PluginRemoveFiles
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.IO;

    using Core.Enums;
    using Core.ValueObjects;

    using Enums;

    using filehandler.Plugin;

    using ValueObjects;

    #endregion

    public class Plugin : PluginBase
    {
        public Plugin()
        {
            Name = "Remove Files";
            Description = "Specify which file types (by extension) should be deleted";
            Extensions = new List<String>();
            VersionMajor = 1; // Last changed 2017-06-30 T 1505
            VersionMinor = 1; // Last changed 2017-06-30 T 1505
        }

        public override Boolean Initialize()
        {
            IsInitialized = false;

            DataBridge db = new DataBridge
                            {
                                Extensions = new List<String>(Extensions)
                            };

            new FormExtensions(db).ShowDialog();

            if (db.Status != Status.Saved)
            {
                InitError("Configuration process has been canceled");
                return IsInitialized;
            }

            Extensions = db.Extensions;

            return base.Initialize();
        }

        public override void Action(String path)
        {
            Start();

            if (!File.Exists(path))
            {
                Warning($"File not found for given path '{path}'. Skipping this task");
                Finish();
                return;
            }

            try
            {
                Log(new LogEntry($"{Name}[{Guid}]", $"Trying to delete the file '{path}'...", LogType.Information));
                File.Delete(path);
                Log(new LogEntry($"{Name}[{Guid}]", $"Deleted the file '{path}'", LogType.Information));
                Finish();
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                Finish();
            }
        }
    }
}
namespace ch.wuerth.tobias.filehandler.PluginRemoveFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Core.Enums;
    using Core.ValueObjects;
    using Enums;
    using filehandler.Plugin;
    using ValueObjects;

    public class Plugin : PluginBase
    {
        public Plugin()
        {
            Name = "Remove Files";
            Description = "Specify which file types (by extension) should be deleted";
            Extensions = new List<String>();
        }

        public override void Initialize()
        {
            DataBridge db = new DataBridge();
            new FormExtensions(db).ShowDialog();
            if (db.Status != Status.Saved)
            {
                InitError("Configuration process has been canceled");
                return;
            }

            Extensions = db.Extensions;

            base.Initialize();
        }

        public override void Action(String path)
        {
            if (!File.Exists(path))
            {
                Log(new LogEntry(Name, $"File not found for given path '{path}'. Skipping this task", LogType.Warning));
                return;
            }


        }
    }
}

namespace PluginUnrar
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;

    using ch.wuerth.tobias.filehandler.Core.Enums;
    using ch.wuerth.tobias.filehandler.Core.ValueObjects;
    using ch.wuerth.tobias.filehandler.Plugin;

    using Enums;

    using ValueObjects;

    #endregion

    public class Plugin : PluginBase
    {
        private readonly DataBridge _configuration = new DataBridge();

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
                if (VerifyName(path))
                {
                    String dir = Path.GetDirectoryName(path);
                    String args = "e -ac -ai -c- -cfg- -dh -ep -or -r -u";
                    if (_configuration.CreateSubdirectory.Value)
                    {
                        args += " -ad";
                    }
                    List<Process> processes = new List<Process>();
                    if (_configuration.UsePasswords.Value)
                    {
                        _configuration.Passwords.ForEach(x => processes.Add(BuildProcess(args, path, dir, x)));
                    }
                    else
                    {
                        processes.Add(BuildProcess(args, path, dir));
                    }
                    foreach (Process x in processes)
                    {
                        try
                        {
                            Int32 errors = 0;
                            x.ErrorDataReceived += (o, e) =>
                                                   {
                                                       String data = e?.Data?.Trim();
                                                       if (!String.IsNullOrEmpty(data))
                                                       {
                                                           errors++;
                                                       }
                                                   };
                            Log(new LogEntry($"{Name}", $"Starting extraction process for file '{path}'...", LogType.Information));
                            x.Start();
                            x.BeginErrorReadLine();
                            x.BeginOutputReadLine();
                            x.WaitForExit();
                            Log(new LogEntry($"{Name}", $"Process for file '{path}' has finished", LogType.Information));
                            if (!errors.Equals(0))
                            {
                                continue;
                            }

                            Log(new LogEntry($"{Name}", $"Zero errors found, assuming a successful extraction for file '{path}'.", LogType.Information));
                            if (!_configuration.DeleteArchiveAfterExtraction.Value)
                            {
                                continue;
                            }

                            Log(new LogEntry($"{Name}", $"Trying to delete archive '{path}'...", LogType.Information));
                            File.Delete(path);
                            Log(new LogEntry($"{Name}", $"Successfully deleted archive '{path}'.", LogType.Information));
                            break;
                        }
                        catch (Exception ex)
                        {
                            Error(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }

            Finish();
        }

        private Boolean VerifyName(String path)
        {
            String filename = Path.GetFileNameWithoutExtension(path) ?? String.Empty;
            Regex r = new Regex(@"\.part([0]*1)");
            Match match = r.Match(filename);
            if (match.Success)
            {
                Log(new LogEntry(Name, $"Identified file '{path} as first part of multiple'.", LogType.Information));
                return true;
            }

            r = new Regex(@"\.part([0-9]+)");
            match = r.Match(filename);

            if (match.Success)
            {
                Log(new LogEntry(Name, $"Identified file '{path}' as part of a multipart archive. This file does not seem to be the first one and will be ignored.", LogType.Information));
                return false;
            }

            return true;
        }

        private Process BuildProcess(String args, String path, String dir, String password = null)
        {
            Process p = new Process
                        {
                            EnableRaisingEvents = true,
                            StartInfo =
                            {
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                WorkingDirectory = _configuration.WinrarDirectory,
                                FileName = _configuration.WinrarExe,
                                CreateNoWindow = true,
                                Arguments = String.IsNullOrEmpty(password) ? $"{args} -p- \"{path}\" * \"{dir}\"" : $"{args} -p{password} \"{path}\" * \"{dir}\""
                            }
                        };
            p.ErrorDataReceived += (o, e) =>
                                   {
                                       String message = e?.Data?.Trim();
                                       if (!String.IsNullOrEmpty(message))
                                       {
                                           Log(new LogEntry($"{Name} output", message, LogType.Error));
                                           Error(message);
                                       }
                                   };
            p.OutputDataReceived += (o, e) =>
                                    {
                                        String message = e?.Data?.Trim();
                                        if (!String.IsNullOrEmpty(message))
                                        {
                                            Log(new LogEntry($"{Name} output", message, LogType.Information));
                                        }
                                    };
            return p;
        }
    }
}
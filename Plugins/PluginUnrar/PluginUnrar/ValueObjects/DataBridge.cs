namespace PluginUnrar.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class DataBridge
    {
        public String WinrarDirectory
        {
            get;
            set;
        }

        public String WinrarExe
        {
            get;
            set;
        }

        public Boolean? CreateSubdirectory
        {
            get;
            set;
        }

        public Boolean? DeleteArchiveAfterExtraction
        {
            get;
            set;
        }

        public Boolean? UsePasswords
        {
            get;
            set;
        }

        public List<String> Passwords
        {
            get;
            set;
        }

        public Status Status
        {
            get;
            set;
        }
    }
}
namespace ch.wuerth.tobias.filehandler.Plugin
{
    #region usings

    using System;
    using System.Collections.Generic;

    using Core.Exceptions;
    using Core.Interfaces;
    using Core.ValueObjects;

    #endregion

    public abstract class PluginBase
    {
        public delegate void OnErrorEvent(String message);

        public delegate void OnFinishEvent();

        public delegate void OnInitErrorEvent(String message);

        public delegate void OnInitSuccessEvent();

        public delegate void OnStartEvent();

        public delegate void OnWarningEvent(String message);

        public readonly Guid Guid = Guid.NewGuid();
        private String _description;
        private List<String> _extensions;
        private ILogger _logger;
        private String _name;

        public OnErrorEvent OnError { get; set; }

        public OnFinishEvent OnFinish { get; set; }

        public OnStartEvent OnStart { get; set; }

        public OnWarningEvent OnWarning { get; set; }

        public OnInitSuccessEvent OnInitSuccess { get; set; }

        public OnInitErrorEvent OnInitError { get; set; }

        public String Name { get => _name ?? throw new UndefinedValueException(); protected set => _name = value; }

        public Int32 VersionMajor { get; protected set; }

        public Int32 VersionMinor { get; protected set; }

        public ILogger Logger { get => _logger ?? throw new UndefinedValueException(); set => _logger = value; }

        public String Description { get => _description ?? throw new UndefinedValueException(); protected set => _description = value; }

        public List<String> Extensions { get => _extensions ?? throw new UndefinedValueException(); protected set => _extensions = value; }

        public Boolean IsInitialized { get; protected set; }

        protected void Log(LogEntry entry)
        {
            Logger?.Log(entry);
        }

        protected void Error(String message)
        {
            OnError?.Invoke(message);
        }

        protected void Finish()
        {
            OnFinish?.Invoke();
        }

        protected void Start()
        {
            OnStart?.Invoke();
        }

        protected void Warning(String message)
        {
            OnWarning?.Invoke(message);
        }

        protected void InitSuccess()
        {
            OnInitSuccess?.Invoke();
        }

        protected void InitError(String message)
        {
            OnInitError?.Invoke(message);
        }

        public virtual Boolean Initialize()
        {
            IsInitialized = true;
            InitSuccess();
            return IsInitialized;
        }

        public abstract void Action(String path);
    }
}
namespace ch.wuerth.tobias.filehandler.Plugin
{
    #region usings

    using System;
    using System.Collections;
    using System.Collections.Generic;

    #endregion

    public abstract class PluginBase
    {
        public delegate void OnErrorEvent(String message);

        public delegate void OnFinishEvent();

        public delegate void OnInitErrorEvent(String message);

        public delegate void OnInitSuccessEvent();

        public delegate void OnStartEvent();

        public delegate void OnSuccessEvent();

        public delegate void OnWarningEvent(String message);

        public OnErrorEvent OnError { private get; set; }
        public OnFinishEvent OnFinish { private get; set; }
        public OnStartEvent OnStart { private get; set; }
        public OnSuccessEvent OnSuccess { private get; set; }
        public OnWarningEvent OnWarning { private get; set; }
        public OnInitSuccessEvent OnInitSuccess { private get; set; }
        public OnInitErrorEvent OnInitError { private get; set; }

        public String Name { get; protected set; }
        public Int32 VersionMajor { get; protected set; }
        public Int32 VersionMinor { get; protected set; }
        public Int32 Description { get; protected set; }
        public IList<String> Extensions { get; protected set; }

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

        protected void Success()
        {
            OnSuccess?.Invoke();
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

        protected abstract void OnInit();
    }
}
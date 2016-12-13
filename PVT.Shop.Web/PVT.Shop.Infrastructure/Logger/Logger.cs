namespace PVT.Shop.Infrastructure.Logger
{
    public class Logger
    {
        private ILogSaver _saver;

        public Logger(ILogSaver saver)
        {
            this._saver = saver;
        }

        public bool IsEnabled { get; set; }

        public void Save(ILogEvent logEvent)
        {
            if(IsEnabled)
            {
                this._saver.Save(logEvent); 
            }
        }

        public void Save(string path, ILogEvent logEvent)
        {
            if(IsEnabled)
            {
                this._saver.Save(path, logEvent); 
            }
        }
    }
}
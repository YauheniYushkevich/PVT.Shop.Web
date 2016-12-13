namespace PVT.Shop.Infrastructure.Logger
{
    using System.IO;

    public class LogToTxtSaver : ILogSaver
    {
        private string _path;

        private static object _locker = new object();

        public LogToTxtSaver()
        {
        }

        public LogToTxtSaver(string path)
        {
            this._path = path;
        }

        public void Save(ILogEvent logEvent)
        {
            lock(_locker)
            {
                using(var fileStream = new FileStream(this._path, FileMode.Append))
                {
                    using(var streamWriter = new StreamWriter(fileStream))
                    {
                        try
                        {
                            streamWriter.WriteLine(logEvent.ToString());
                        }
                        catch(System.Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                } 
            }
        }

        public void Save(string path, ILogEvent logEvent)
        {
            this._path = path;

            lock(_locker)
            {
                using(var fileStream = new FileStream(this._path, FileMode.Append))
                {
                    using(var streamWriter = new StreamWriter(fileStream))
                    {
                        try
                        {
                            streamWriter.WriteLine(logEvent.ToString());
                        }
                        catch(System.Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                } 
            }
        }
    }
}

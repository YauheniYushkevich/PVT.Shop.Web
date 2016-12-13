namespace PVT.Shop.Infrastructure.Logger
{
    using System;

    public enum LogLevel
    {
        Debug,
        Error,
        Fatal,
        Info,
        Trace,
        Warn
    }

    public interface ILogEvent
    {
        int Id { get; set; }

        LogLevel LogLevel { get; set; }

        DateTime EventDateTime { get; set; }

        string Message { get; set; }
    }
}

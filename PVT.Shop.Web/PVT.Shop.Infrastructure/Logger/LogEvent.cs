namespace PVT.Shop.Infrastructure.Logger
{
    using System;

    public class LogEvent : ILogEvent
    {
        public DateTime EventDateTime { get; set; }

        public int Id { get; set; }

        public LogLevel LogLevel { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"Time: {EventDateTime.ToShortTimeString()}; Log level: {LogLevel}; Message: {Message}";
        }
    }
}
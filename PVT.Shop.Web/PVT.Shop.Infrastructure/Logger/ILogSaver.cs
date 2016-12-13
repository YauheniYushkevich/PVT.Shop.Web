namespace PVT.Shop.Infrastructure.Logger
{
    public interface ILogSaver
    {
        void Save(ILogEvent logEvent);

        void Save(string path, ILogEvent logEvent);
    }
}

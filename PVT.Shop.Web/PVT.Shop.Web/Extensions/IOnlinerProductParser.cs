namespace PVT.Shop.Web.Extensions
{
    public interface IOnlinerProductParser
    {
        void ParseCatalog(string type, int group, int category, int storage, int user);
    }
}
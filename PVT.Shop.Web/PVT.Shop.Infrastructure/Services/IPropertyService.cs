namespace PVT.Shop.Infrastructure.Services
{
    using Common;

    public interface IPropertyService
    {
        Property Get(int id);

        void Save(Property property);
    }
}
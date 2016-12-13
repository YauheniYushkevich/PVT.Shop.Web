namespace PVT.Shop.Web.DAL.Repositories
{
    using Infrastructure.Common;
    using Infrastructure.Repositories;

    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(ShopContext db) : base(db)
        {
        }
    }
}
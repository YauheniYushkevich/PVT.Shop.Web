namespace PVT.Shop.Web.DAL.Repositories
{
    using Infrastructure.Common;
    using Infrastructure.Repositories;

    public class PropertyValueRepository : Repository<PropertyValue>, IPropertyValueRepository
    {
        public PropertyValueRepository(ShopContext db) : base(db)
        {
        }
    }
}
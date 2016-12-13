namespace PVT.Shop.Web.DAL.Repositories
{
    using Infrastructure.Common;
    using Infrastructure.Repositories;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext db) : base(db)
        {
        }
    }
}
namespace PVT.Shop.Web.DAL
{
    using System.Data.Entity;
    using Infrastructure.Common;
    using Migrations;

    public class ShopContext : DbContext
    {
        public ShopContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyValue> PropertyValues { get; set; }

        public DbSet<Storage> Storages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<BasketProductID> BasketProductIDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new OrderConfig());
        }
    }
}
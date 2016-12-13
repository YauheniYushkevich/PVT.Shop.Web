namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopContext context)
        {
            CountryInitializer.Initialize(context);

            StorageInitializer.Initialize(context);

            CategoriesInitializer.Initialize(context);

            UsersInitializer.Initialize(context);

            OrderInitializer.Initialize(context);

            context.SaveChanges();
        }
    }
}
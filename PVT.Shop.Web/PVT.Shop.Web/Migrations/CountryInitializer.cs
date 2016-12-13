namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;

    public static class CountryInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            context.Countries.AddRange(new List<Country>()
            {
                new Country() { Name = "Belarus" },
                new Country() { Name = "Russia" },
                new Country() { Name = "Ukraine" },
                new Country() { Name = "Poland" },
                new Country() { Name = "Latvia" },
                new Country() { Name = "Lithuania" },
            });
        }
    }
}
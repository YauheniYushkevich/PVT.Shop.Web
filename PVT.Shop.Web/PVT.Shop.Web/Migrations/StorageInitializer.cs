namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;

    public static class StorageInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Storages.Any())
            {
                context.Storages.AddOrUpdate(
                new Storage
                {
                    Name = "Storage 1",
                    Address = new Address
                    {
                        City = "Minsk",
                        Postcode = "123456",
                        ApartmentNumber = "123",
                        HomeNumber = "123",
                        Street = "Minskay"
                    },
                    PhoneNumber = "12345600"
                },
                new Storage
                {
                    Name = "Storage 2",
                    Address = new Address
                    {
                        City = "Pinsk",
                        Postcode = "654321",
                        ApartmentNumber = "654",
                        HomeNumber = "654",
                        Street = "Pinskay"
                    },
                    PhoneNumber = "65432100"
                });
            }

            try
            {
                foreach (var storage in context.Storages.Local)
                {
                    storage.Address.Country = context.Countries.Local.FirstOrDefault(c => c.Name == "Belarus");
                }

                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("\nStorageInitializer_Initialize: " + ex.Message + "\n");
            }
        }
    }
}
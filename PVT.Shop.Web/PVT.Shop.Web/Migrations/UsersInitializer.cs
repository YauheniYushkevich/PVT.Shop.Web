namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;

    public class UsersInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(
                    x => x.Id,
                    new User
                    {
                        Login = "Kondratenko",
                        Email = "Dmitry@gmail.com",
                        Password = "123",
                        PasswordConfirm = "123",
                        Birthday = new DateTime(1986, 12, 4),
                        FirstName = "Dmitry",
                        LastName = "Kondratenko",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Belarus" },
                                      City = "Minsk",
                                      Postcode = "220006",
                                      Street = "Mayakovski",
                                      HomeNumber = "14",
                                      ApartmentNumber = "100"
                                  },
                        Phone = "100-00-00"
                    },
                    new User
                    {
                        Login = "JhonSmith",
                        Email = "Jhon@gmail.com",
                        Password = "111",
                        PasswordConfirm = "111",
                        Birthday = new DateTime(1990, 10, 5),
                        FirstName = "Jhon",
                        LastName = "Smith",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "England" },
                                      City = "London",
                                      Postcode = "1000000",
                                      Street = "RoyalKing",
                                      HomeNumber = "1",
                                      ApartmentNumber = "133"
                                  },
                        Phone = "200-10-00"
                    },
                    new User
                    {
                        Login = "LenaMiheiko",
                        Email = "Lena@gmail.com",
                        Password = "Lena",
                        PasswordConfirm = "Lena",
                        Birthday = new DateTime(1993, 1, 15),
                        FirstName = "Lena",
                        LastName = "Miheiko",
                        Gender = Gender.Women,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Russia" },
                                      City = "Moscow",
                                      Postcode = "123456",
                                      Street = "prospMira",
                                      HomeNumber = "10",
                                      ApartmentNumber = "123"
                                  },
                        Phone = "300-00-00"
                    },
                    new User
                    {
                        Login = "Belpyro",
                        Email = "Belpyro@gmail.com",
                        Password = "Belpyro",
                        PasswordConfirm = "Belpyro",
                        Birthday = new DateTime(1981, 2, 10),
                        FirstName = "Alex",
                        LastName = "Shaduro",
                        Gender = Gender.Man,
                        Role = Role.Admin,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Belarus" },
                                      City = "Minsk",
                                      Postcode = "123456",
                                      Street = "prospIndependency",
                                      HomeNumber = "10",
                                      ApartmentNumber = "123"
                                  },
                        Phone = "400-00-00"
                    },
                    new User
                    {
                        Login = "MacAndry",
                        Email = "MacAndry@gmail.com",
                        Password = "MacAndry",
                        PasswordConfirm = "MacAndry",
                        Birthday = new DateTime(1993, 2, 10),
                        FirstName = "Andry",
                        LastName = "Makarevich",
                        Gender = Gender.Man,
                        Role = Role.Seller,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Belarus" },
                                      City = "Minsk",
                                      Postcode = "111111",
                                      Street = "SellerStreet",
                                      HomeNumber = "1",
                                      ApartmentNumber = "1"
                                  },
                        Phone = "500-00-00"
                    },
                    new User
                    {
                        Login = "AnjGoly",
                        Email = "AnjGoly@gmail.com",
                        Password = "AnjGoly",
                        PasswordConfirm = "AnjGoly",
                        Birthday = new DateTime(1976, 1, 1),
                        FirstName = "Anjelina",
                        LastName = "Golly",
                        Gender = Gender.Women,
                        Role = Role.Seller,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "USA" },
                                      City = "LosAngeles",
                                      Postcode = "100000",
                                      Street = "BlvSunset",
                                      HomeNumber = "1",
                                      ApartmentNumber = "1"
                                  },
                        Phone = "600-00-00"
                    },
                    new User
                    {
                        Login = "BradPitt",
                        Email = "BradPitt@gmail.com",
                        Password = "BradPitt",
                        PasswordConfirm = "BradPitt",
                        Birthday = new DateTime(1965, 1, 1),
                        FirstName = "Brad",
                        LastName = "Pitt",
                        Gender = Gender.Man,
                        Role = Role.Seller,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "USA" },
                                      City = "LosAngeles",
                                      Postcode = "100000",
                                      Street = "BlvSunset",
                                      HomeNumber = "1",
                                      ApartmentNumber = "1"
                                  },
                        Phone = "700-00-00"
                    },
                    new User
                    {
                        Login = "Gandalf",
                        Email = "Gandalf@gmail.com",
                        Password = "Gandalf",
                        PasswordConfirm = "Gandalf",
                        Birthday = new DateTime(1910, 1, 1),
                        FirstName = "Gandalf",
                        LastName = "Gray",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "NewZeland" },
                                      City = "Vellington",
                                      Postcode = "123456",
                                      Street = "GandalfStreet",
                                      HomeNumber = "1",
                                      ApartmentNumber = "1"
                                  },
                        Phone = "800-00-00"
                    },
                    new User
                    {
                        Login = "Lukashenko",
                        Email = "Lukashenko@gmail.com",
                        Password = "Lukashenko",
                        PasswordConfirm = "Lukashenko",
                        Birthday = new DateTime(1958, 7, 6),
                        FirstName = "Alex",
                        LastName = "Lukashenko",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Belarus" },
                                      City = "Minsk",
                                      Postcode = "220000",
                                      Street = "PresidentStreet",
                                      HomeNumber = "1",
                                      ApartmentNumber = "1"
                                  },
                        Phone = "900-00-00"
                    },
                    new User
                    {
                        Login = "Putin",
                        Email = "Putin@gmail.com",
                        Password = "Putin",
                        PasswordConfirm = "Putin",
                        Birthday = new DateTime(1955, 1, 5),
                        FirstName = "Vladimir",
                        LastName = "Putin",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Russia" },
                                      City = "Moscow",
                                      Postcode = "777777",
                                      Street = "Kreml",
                                      HomeNumber = "1",
                                      ApartmentNumber = "1"
                                  },
                        Phone = "110-00-00"
                    },
                    new User
                    {
                        Login = "Ivanov",
                        Email = "Ivanov@gmail.com",
                        Password = "Ivanov",
                        PasswordConfirm = "Ivanov",
                        Birthday = new DateTime(1980, 2, 6),
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        Gender = Gender.Man,
                        Role = Role.Seller,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Ukraine" },
                                      City = "Kiev",
                                      Postcode = "765432",
                                      Street = "Maidan",
                                      HomeNumber = "99",
                                      ApartmentNumber = "55"
                                  },
                        Phone = "120-00-00"
                    },
                    new User
                    {
                        Login = "Petrov",
                        Email = "Petrov@gmail.com",
                        Password = "Petrov",
                        PasswordConfirm = "Petrov",
                        Birthday = new DateTime(1979, 4, 25),
                        FirstName = "Petr",
                        LastName = "Petrov",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Bulgary" },
                                      City = "Sophia",
                                      Postcode = "123456",
                                      Street = "CenterStr",
                                      HomeNumber = "7",
                                      ApartmentNumber = "7"
                                  },
                        Phone = "130-00-00"
                    },
                    new User
                    {
                        Login = "Masha",
                        Email = "Masha@gmail.com",
                        Password = "Masha",
                        PasswordConfirm = "Masha",
                        Birthday = new DateTime(1999, 2, 10),
                        FirstName = "Masha",
                        LastName = "Andreeva",
                        Gender = Gender.Women,
                        Role = Role.Seller,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Israel" },
                                      City = "TelAviv",
                                      Postcode = "999999",
                                      Street = "Seller",
                                      HomeNumber = "10",
                                      ApartmentNumber = "10"
                                  },
                        Phone = "140-00-00"
                    },
                    new User
                    {
                        Login = "Merkel",
                        Email = "Merkel@gmail.com",
                        Password = "Merkel",
                        PasswordConfirm = "Merkel",
                        Birthday = new DateTime(1948, 10, 10),
                        FirstName = "Angela",
                        LastName = "Merkel",
                        Gender = Gender.Women,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "Germany" },
                                      City = "Berlin",
                                      Postcode = "800000",
                                      Street = "BrandenburgStreet",
                                      HomeNumber = "5",
                                      ApartmentNumber = "33"
                                  },
                        Phone = "150-00-00"
                    },
                    new User
                    {
                        Login = "Mandella",
                        Email = "Mandella@gmail.com",
                        Password = "Mandella",
                        PasswordConfirm = "Mandella",
                        Birthday = new DateTime(1930, 3, 3),
                        FirstName = "Nelson",
                        LastName = "Mandella",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "SAR" },
                                      City = "Pretoria",
                                      Postcode = "333555",
                                      Street = "AfricaStreet",
                                      HomeNumber = "1",
                                      ApartmentNumber = "1"
                                  },
                        Phone = "160-00-00"
                    },
                    new User
                    {
                        Login = "Batman",
                        Email = "Batman@gmail.com",
                        Password = "Batman",
                        PasswordConfirm = "Batman",
                        Birthday = new DateTime(1975, 3, 5),
                        FirstName = "Bat",
                        LastName = "Batman",
                        Gender = Gender.Man,
                        Role = Role.User,
                        Address = new Address
                                  {
                                      Country = new Country { Name = "USA" },
                                      City = "Gotham",
                                      Postcode = "999666",
                                      Street = "BlackStreet",
                                      HomeNumber = "13",
                                      ApartmentNumber = "13"
                                  },
                        Phone = "170-00-00"
                    });

                context.SaveChanges();
            }
        }
    }
}
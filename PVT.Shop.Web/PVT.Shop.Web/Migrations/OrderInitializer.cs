namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;
    using System;
    using System.Collections.Generic;

    public static class OrderInitializer
    {
        public static void Initialize(ShopContext context)
        {

            if (!context.Orders.Any())
            {
                #region Order1
                context.Orders.Add(
                               new Order
                               {
                                   UserId = 1,
                                   UserName = "Ivan",
                                   PhoneNumber = "555-55-555",
                                   DeliveryType = DeliveryType.Self,
                                   BasketProductID = new List<BasketProductID>()
                               {
                   new BasketProductID
                    {
                       ProductId = 1,
                       ProductName = "Test Product #1",
                       Discount = 5,
                       ProductCount = 10,
                       TotalCost = 95
                   },
                   new BasketProductID
                   {
                       ProductId = 2,
                       ProductName = "Test Product #2",
                       Discount = 0,
                       ProductCount = 1,
                       TotalCost = 999
                   }
                               },
                                   Delivery = new Address
                                   {
                                       Country = new Country() { Name = "England" },
                                       City = "MInsk",
                                       Postcode = "1000000",
                                       Street = "RoyalKing",
                                       HomeNumber = "1",
                                       ApartmentNumber = "133"
                                   },
                                   DateAdded = DateTime.Now,
                                   Delivered = true

                               });

                #endregion
                #region Order2

                context.Orders.Add(
                               new Order
                               {
                                   UserId = 2,
                                   UserName = "Tolya",
                                   PhoneNumber = "777-777-7",

                                   DeliveryType = DeliveryType.Self,
                                   BasketProductID = new List<BasketProductID>()
                               {
                   new BasketProductID
                    {
                       ProductId = 2,
                       ProductName = "Test Product #5",
                       Discount = 5,
                       ProductCount = 10,
                       TotalCost = 95
                   },
                   new BasketProductID
                   {
                       ProductId = 2,
                       ProductName = "Test Product #3",
                       Discount = 0,
                       ProductCount = 1,
                       TotalCost = 999
                   },
                   new BasketProductID
                   {
                       ProductId = 2,
                       ProductName = "Test Product #1",
                       Discount = 0,
                       ProductCount = 1,
                       TotalCost = 999
                   }
                               },
                                   Delivery = new Address
                                   {
                                       Country = new Country() { Name = "England" },
                                       City = "London",
                                       Postcode = "1000000",
                                       Street = "RoyalKing",
                                       HomeNumber = "1",
                                       ApartmentNumber = "133"
                                   },
                                   DateAdded = DateTime.Now,
                                   Delivered = false

                               });
                #endregion
                #region Order3
                context.Orders.Add(
                               new Order
                               {
                                   UserId = 3,
                                   UserName = "Kostya",
                                   PhoneNumber = "599-55-555",
                                   DeliveryType = DeliveryType.Self,
                                   BasketProductID = new List<BasketProductID>()
                               {
                   new BasketProductID
                    {
                       ProductId = 3,
                       ProductName = "Test Product #3",
                       Discount = 5,
                       ProductCount = 10,
                       TotalCost = 95
                   },

                               },
                                   Delivery = new Address
                                   {
                                       Country = new Country() { Name = "England" },
                                       City = "London",
                                       Postcode = "1000000",
                                       Street = "RoyalKing",
                                       HomeNumber = "1",
                                       ApartmentNumber = "133"
                                   },
                                   DateAdded = DateTime.Now,
                                   Delivered = true

                               });

                #endregion
                #region Order 4
                context.Orders.Add(
                             new Order
                             {
                                 UserId = 1,
                                 UserName = "Ivan",
                                 PhoneNumber = "555-55-555",
                                 DeliveryType = DeliveryType.Self,
                                 BasketProductID = new List<BasketProductID>()
                             {
                   new BasketProductID
                    {
                       ProductId = 1,
                       ProductName = "Test Product #1",
                       Discount = 5,
                       ProductCount = 10,
                       TotalCost = 95
                   },
                   new BasketProductID
                   {
                       ProductId = 2,
                       ProductName = "Test Product #2",
                       Discount = 0,
                       ProductCount = 1,
                       TotalCost = 999
                   }
                             },
                                 Delivery = new Address
                                 {
                                     Country = new Country() { Name = "England" },
                                     City = "London",
                                     Postcode = "1000000",
                                     Street = "RoyalKing",
                                     HomeNumber = "1",
                                     ApartmentNumber = "133"
                                 },
                                 DateAdded = DateTime.Now,
                                 Delivered = true

                             });
                #endregion
                #region Order 5
                context.Orders.Add(
                              new Order
                              {
                                  UserId = 1,
                                  UserName = "Ivan",
                                  PhoneNumber = "555-55-555",
                                  DeliveryType = DeliveryType.Self,
                                  BasketProductID = new List<BasketProductID>()
                              {
                   new BasketProductID
                    {
                       ProductId = 1,
                       ProductName = "Test Product #1",
                       Discount = 5,
                       ProductCount = 10,
                       TotalCost = 95
                   },
                   new BasketProductID
                   {
                       ProductId = 5,
                       ProductName = "Test Product #1",
                       Discount = 0,
                       ProductCount = 1,
                       TotalCost = 999
                   }
                              },
                                  Delivery = new Address
                                  {
                                      Country = new Country() { Name = "England" },
                                      City = "London",
                                      Postcode = "1000000",
                                      Street = "RoyalKing",
                                      HomeNumber = "1",
                                      ApartmentNumber = "133"
                                  },
                                  DateAdded = DateTime.Now,
                                  Delivered = true

                              });
                #endregion
                #region Order 6
                context.Orders.Add(
                              new Order
                              {
                                  UserId = 7,
                                  UserName = "Ivan",
                                  PhoneNumber = "555-55-555",
                                  DeliveryType = DeliveryType.Self,
                                  BasketProductID = new List<BasketProductID>()
                              {
                   new BasketProductID
                    {
                       ProductId = 7,
                       ProductName = "Test Product #7",
                       Discount = 5,
                       ProductCount = 5,
                       TotalCost = 95
                   },
                   new BasketProductID
                   {
                       ProductId = 2,
                       ProductName = "Test Product #2",
                       Discount = 0,
                       ProductCount = 1,
                       TotalCost = 999
                   }
                              },
                                  Delivery = new Address
                                  {
                                      Country = new Country() { Name = "England" },
                                      City = "London",
                                      Postcode = "1000000",
                                      Street = "RoyalKing",
                                      HomeNumber = "1",
                                      ApartmentNumber = "133"
                                  },
                                  DateAdded = DateTime.Now,
                                  Delivered = true

                              });
                #endregion

            }

            try
            {
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("\n OrderInitializer_Initialize: " + ex.Message + "\n");
            }
        }
    }
}
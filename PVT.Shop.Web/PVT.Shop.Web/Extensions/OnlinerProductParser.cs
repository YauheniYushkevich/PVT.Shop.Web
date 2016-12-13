namespace PVT.Shop.Web.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Infrastructure.Common;
    using Infrastructure.Services;
    using Newtonsoft.Json.Linq;

    public class OnlinerProductParser : IOnlinerProductParser
    {
        private readonly string _url = "https://catalog.api.onliner.by/search/";

        private readonly IProductService _productService;

        private readonly IUserService _userService;

        public OnlinerProductParser(IProductService productService, IUserService userService)
        {
            this._productService = productService;
            this._userService = userService;
        }

        public void ParseCatalog(string type, int group, int category, int storage, int user)
        {
            var client = new HttpClient();
            var rand = new Random();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var setting = client.GetStringAsync($"{this._url + type}?group={group}");
            var pages = (int)JObject.Parse(setting.Result)["page"]["last"];

            for (var i = 1; i < pages + 1; i++)
            {
                var response = client.GetStringAsync($"{this._url + type}?group={group}&page={i}");

                IList<JToken> productList = JObject.Parse(response.Result)["products"].Children().ToList();

                foreach (var p in productList)
                {
                    var fullName = (string)p["full_name"];

                    var description = ((string)p["description"]).Replace("&nbsp;", " ");

                    string image;

                    if (p["images"].HasValues)
                    {
                        image = "http:" + (string)p["images"]["header"];
                    }
                    else
                    {
                        continue;
                    }

                    decimal price;

                    if (p["prices"].HasValues)
                    {
                        price = ((decimal)p["prices"]["price_min"]["amount"]) / (decimal)1.95;
                    }
                    else
                    {
                        continue;
                    }

                    var numberOfSellers = this._userService.GetAllUsers().Where(x => x.Role == Role.Seller);

                    var randomSeller = rand.Next(0, numberOfSellers.Count());

                    var product = new Product
                    {
                        Name = fullName,
                        Description = description,
                        Count = rand.Next(1, 200),
                        Display = true,
                        Price = price,
                        Image = image,
                        CurrentCategoryId = category,
                        CurrentStorageId = storage,
                        CurrentUserId = numberOfSellers.ElementAt(randomSeller).Id
                    };

                    this._productService.AddProduct(product);
                    this._productService.SaveChanges();
                }
            }
        }
    }
}
namespace PVT.Shop.Web
{
    using System;
    using System.Web.Mvc;
    using Infrastructure.Common;

    public class StorageModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            int storageId = Convert.ToInt32(request.Form["Storage.Id"]);

            string storageName = request.Form["Storage.Name"];

            string storagePhone = request.Form["Storage.PhoneNumber"];

            int storageAddressId = Convert.ToInt32(request.Form["Storage.Address.Id"]);

            int storageCountryId = Convert.ToInt32(request.Form["Storage.Address.Country"]);

            string storagePostcode = request.Form["Storage.Address.Postcode"];

            string storageCity = request.Form["Storage.Address.City"];

            string storageStreet = request.Form["Storage.Address.Street"];

            string storageBuilding = request.Form["Storage.Address.HomeNumber"];

            string storageApartment = request.Form["Storage.Address.ApartmentNumber"];

            Storage storage = new Storage()
                              {
                                  Id = storageId,
                                  Name = storageName,
                                  PhoneNumber = storagePhone,
                                  Address = new Address()
                                            {
                                                Id = storageAddressId,
                                                Country = new Country() { Id = storageCountryId },
                                                City = storageCity,
                                                Postcode = storagePostcode,
                                                Street = storageStreet,
                                                HomeNumber = storageBuilding,
                                                ApartmentNumber = storageApartment
                                            }
                              };

            return storage;
        }
    }
}
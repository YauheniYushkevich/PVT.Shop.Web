namespace PVT.Shop.Web
{
    using DAL.Repositories;
    using Extensions;
    using Infrastructure.Common;
    using Infrastructure.Logger;
    using Infrastructure.Repositories;
    using Infrastructure.Services;
    using Ninject.Modules;
    using Services;

    public class InitModule : NinjectModule
    {
        public override void Load()
        {
            ////Product Storage
            this.Bind<ICategoryService>().To<CategoryService>();
            this.Bind<IStorageService>().To<StorageService>();
            this.Bind<IProductService>().To<ProductService>();
            this.Bind<IAddressService>().To<AddressService>();
            this.Bind<ICountryService>().To<CountryService>();

            ////User Role
            this.Bind<IUserService>().To<UserService>();

            ////Product Storage
            this.Bind<ICategoryRepository>().To<CategoryRepository>();
            this.Bind<IPropertyRepository>().To<PropertyRepository>();
            this.Bind<IProductRepository>().To<ProductRepository>();
            this.Bind<IPropertyValueRepository>().To<PropertyValueRepository>();
            this.Bind<IRepository<Storage>>().To<StorageRepository>();
            this.Bind<IRepository<Address>>().To<AddressRepository>();
            this.Bind<IRepository<Country>>().To<CountryRepository>();

            ////Basket Order
            this.Bind<IRepository<Order>>().To<Repository<Order>>();
            this.Bind<IRepository<BasketProductID>>().To<Repository<BasketProductID>>();
            this.Bind<IOrderService>().To<OrderService>();

            ////Logger
            this.Bind<Logger>().ToSelf();
            this.Bind<ILogEvent>().To<LogEvent>();
            this.Bind<ILogSaver>().To<LogToTxtSaver>();

            //// Parser 
            this.Bind<IOnlinerProductParser>().To<OnlinerProductParser>();
        }
    }
}
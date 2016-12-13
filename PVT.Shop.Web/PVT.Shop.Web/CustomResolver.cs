namespace PVT.Shop.Web
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Infrastructure.Services;
    using Ninject;
    using Services;

    public class CustomResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public CustomResolver(IKernel kernel)
        {
            this._kernel = kernel;
            this.AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this._kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this._kernel.Bind<ICalculator>().To<Calculator>();
        }
    }
}
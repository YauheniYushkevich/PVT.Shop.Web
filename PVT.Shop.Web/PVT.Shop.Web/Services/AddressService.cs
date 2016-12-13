namespace PVT.Shop.Web.Services
{
    using System;
    using System.Linq;
    using Infrastructure.Common;
    using Infrastructure.Repositories;
    using Infrastructure.Services;

    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _repository;

        private bool _disposedValue;

        public AddressService(IRepository<Address> repository)
        {
            this._repository = repository;
        }

        ~AddressService()
        {
            this.Dispose(false);
        }

        public void AddAddress(Address address)
        {
            this._repository.Create(address);
        }

        public void DeleteAddress(int id)
        {
            this._repository.Delete(id);
        }

        public void UpdateAddress(Address address)
        {
            this._repository.Update(address);
        }

        public void SaveAddress()
        {
            this._repository.Save();
        }

        public Address GetAddress(int id)
        {
            return this._repository.GetById(id);
        }

        public IQueryable<Address> GetAddresses()
        {
            return this._repository.GetAll().AsQueryable();
        }

        #region IDisposable Support

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposedValue)
            {
                return;
            }

            if (disposing)
            {
                this._repository.Dispose();
            }

            this._disposedValue = true;
        }

        #endregion
    }
}
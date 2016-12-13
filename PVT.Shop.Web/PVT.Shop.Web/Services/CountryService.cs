namespace PVT.Shop.Web.Services
{
    using System;
    using System.Linq;
    using Infrastructure.Common;
    using Infrastructure.Repositories;
    using Infrastructure.Services;

    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _repository;

        private bool _disposedValue;

        public CountryService(IRepository<Country> repository)
        {
            this._repository = repository;
        }

        ~CountryService()
        {
            this.Dispose(false);
        }

        public void AddCountry(Country country)
        {
            this._repository.Create(country);
        }

        public void DeleteCountry(int id)
        {
            this._repository.Delete(id);
        }

        public IQueryable<Country> GetCountries()
        {
            return this._repository.GetAll().AsQueryable();
        }

        public void SaveCountry()
        {
            this._repository.Save();
        }

        public Country GetCountry(int id)
        {
            return this._repository.GetById(id);
        }

        public void UpdateCountry(Country country)
        {
            this._repository.Update(country);
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
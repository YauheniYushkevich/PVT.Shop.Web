namespace PVT.Shop.Infrastructure.Services
{
    using System;
    using System.Linq;
    using Common;

    public interface ICountryService : IDisposable
    {
        void AddCountry(Country country);

        void DeleteCountry(int id);

        void UpdateCountry(Country country);

        void SaveCountry();

        Country GetCountry(int id);

        IQueryable<Country> GetCountries();
    }
}
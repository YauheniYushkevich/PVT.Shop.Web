namespace PVT.Shop.Infrastructure.Services
{
    using System;
    using System.Linq;
    using Common;

    public interface IAddressService : IDisposable
    {
        void AddAddress(Address address);

        void DeleteAddress(int id);

        void UpdateAddress(Address address);

        void SaveAddress();

        Address GetAddress(int id);

        IQueryable<Address> GetAddresses();
    }
}
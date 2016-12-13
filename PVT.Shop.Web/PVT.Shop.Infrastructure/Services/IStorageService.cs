namespace PVT.Shop.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using Common;

    public interface IStorageService : IDisposable
    {
        void AddStorage(Storage storage);

        void DeleteStorage(int id);

        void UpdateStorage(Storage storage);

        Storage GetStorage(int id);

        IEnumerable<Storage> GetStorages();

        IEnumerable<Storage> GetStorages(SortByEnum? sortByNew);

        void SaveStorage();
    }
}
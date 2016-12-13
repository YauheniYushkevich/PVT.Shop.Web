namespace PVT.Shop.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Common;
    using Infrastructure.Repositories;
    using Infrastructure.Services;

    public class StorageService : IStorageService
    {
        private readonly IRepository<Storage> _repository;

        private bool _disposedValue;

        public StorageService(IRepository<Storage> repository)
        {
            this._repository = repository;
        }

        ~StorageService()
        {
            this.Dispose(false);
        }

        public void AddStorage(Storage storage)
        {
            this._repository.Create(storage);
        }

        public void DeleteStorage(int id)
        {
            this._repository.Delete(id);
        }

        public void UpdateStorage(Storage storage)
        {
            this._repository.Update(storage);
        }

        public Storage GetStorage(int id)
        {
            return this._repository.GetById(id);
        }

        public IEnumerable<Storage> GetStorages()
        {
            return this._repository.GetAll();
        }

        public IEnumerable<Storage> GetStorages(SortByEnum? sortByNew)
        {
            IEnumerable<Storage> result;

            switch (sortByNew.Value)
            {
                case
                    SortByEnum.NameDesc:
                    result = this.GetStorages().OrderByDescending(s => s.Name);
                    break;
                case
                    SortByEnum.Country:
                    result = this.GetStorages().OrderBy(s => s.Address.Country.Name);
                    break;
                case
                    SortByEnum.CountryDesc:
                    result = this.GetStorages().OrderByDescending(s => s.Address.Country.Name);
                    break;
                case
                    SortByEnum.City:
                    result = this.GetStorages().OrderBy(s => s.Address.City);
                    break;
                case
                    SortByEnum.CityDesc:
                    result = this.GetStorages().OrderByDescending(s => s.Address.City);
                    break;
                default:
                    result = this.GetStorages().OrderBy(s => s.Name);
                    break;
            }

            return result;
        }

        public void SaveStorage()
        {
            this._repository.Save();
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
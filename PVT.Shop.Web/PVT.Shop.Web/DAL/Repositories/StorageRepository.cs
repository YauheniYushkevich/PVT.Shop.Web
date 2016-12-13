namespace PVT.Shop.Web.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using Infrastructure.Common;
    using Infrastructure.Common.Enums;

    public class StorageRepository : Repository<Storage>
    {
        private readonly ShopContext _db;

        public StorageRepository(ShopContext db) : base(db)
        {
            this._db = db;
        }

        ~StorageRepository()
        {
            this.Dispose(false);
        }

        public override void Create(Storage storage)
        {
            storage.Address.Country = this._db.Countries.FirstOrDefault(c => c.Id == storage.Address.Country.Id);

            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    this._db.Storages.Add(storage);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine("\nStorageRepository_Create: " + ex.Message + "\n");
                }
            }
        }

        public override void Update(Storage storage)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var tempStorage = this.GetById(storage.Id);

                    if (tempStorage != null)
                    {
                        if (tempStorage.Address.Country.Id != storage.Address.Country.Id)
                        {
                            tempStorage.Address.Country =
                                this._db.Countries.FirstOrDefault(c => c.Id == storage.Address.Country.Id);
                        }

                        this._db.Entry(tempStorage.Address).CurrentValues.SetValues(storage.Address);
                        this._db.Entry(tempStorage).CurrentValues.SetValues(storage);

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine("\nStorageRepository_Update: " + ex.Message + "\n");
                }
            }
        }

        public override void Delete(int id)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var tempStorage = this.GetById(id);

                    var tempAddress = this._db.Addresses.FirstOrDefault(a => a.Id == tempStorage.Address.Id);

                    if (tempStorage != null)
                    {
                        this._db.Storages.Remove(tempStorage);

                        this._db.Addresses.Remove(tempAddress);

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine("\nStorageRepository_Delete: " + ex.Message + "\n");
                }
            }
        }

        public override Storage GetById(int id)
        {
            try
            {
                return this._db.Storages.Include(s => s.Address).Include(s => s.Address.Country).FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nStorageRepository_GetById: " + ex.Message + "\n");
            }

            return null;
        }

        public override IEnumerable<Storage> GetAll(Expression<Func<Storage, bool>> filter = null, int? pageNumber = null, int? numberOfObjects = null, OrderType orderType = OrderType.Ascending)
        {
            IEnumerable<Storage> result = null;

            try
            {
                if (filter == null)
                {
                    if (pageNumber == null && numberOfObjects == null)
                    {
                        result = this._db.Storages.Include(s => s.Address).Include(s => s.Address.Country);
                    }
                    else
                    {
                        if (pageNumber == 0 || numberOfObjects == 0)
                        {
                            return null;
                        }

                        result = this._db.Storages.Include(s => s.Address).Include(s => s.Address.Country).Skip((pageNumber.Value - 1) * numberOfObjects.Value).Take(numberOfObjects.Value);
                    }
                }
                else
                {
                    if (pageNumber == null && numberOfObjects == null)
                    {
                        result = this._db.Storages.Include(s => s.Address).Include(s => s.Address.Country).Where(filter);
                    }
                    else
                    {
                        if (pageNumber == 0 || numberOfObjects == 0)
                        {
                            return null;
                        }

                        result = this._db.Storages.Include(s => s.Address).Include(s => s.Address.Country).Where(filter).Skip((pageNumber.Value - 1) * numberOfObjects.Value).Take(numberOfObjects.Value);
                    }
                }

                return orderType == OrderType.Ascending ? result.OrderBy(s => s.Name) : result.OrderByDescending(s => s.Name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nStorageRepository_GetAll: " + ex.Message + "\n");
                return result;
            }
        }
    }
}
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
    using Infrastructure.Repositories;

    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ShopContext _db;

        private bool _disposed;

        public Repository(ShopContext db)
        {
            this._db = db;
        }

        ~Repository()
        {
            this.Dispose(true);
        }

        public virtual void Save()
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    this._db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        }

        #region IDispose

        /// <summary>
        ///     Implement IDisposable.
        ///     Do not make this method virtual.
        ///     A derived class should not be able to override this method.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Dispose(bool disposing) executes in two distinct scenarios.
        ///     If disposing equals true, the method has been called directly
        ///     or indirectly by a user's code. Managed and unmanaged resources
        ///     can be disposed.
        ///     If disposing equals false, the method has been called by the
        ///     runtime from inside the finalizer and you should not reference
        ///     other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._db.Dispose();
                }
            }
                
            this._disposed = true;
        }

        #endregion

        #region CRUD

        public virtual void Create(T entity)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    this._db.Set<T>().Add(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        }

        public virtual void Update(T entity)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    this._db.Entry(entity).State = EntityState.Modified;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        }

        public virtual void Delete(int id)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var entity = this._db.Set<T>().Find(id);
                    entity.IsDeleted = true;

                    this._db.Entry(entity).State = EntityState.Modified;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        }

        public virtual void Restore(int id)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var entity = this._db.Set<T>().Find(id);
                    entity.IsDeleted = false;

                    this._db.Entry(entity).State = EntityState.Modified;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        }

        public virtual void MowToHell(int id)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var ent = this._db.Set<T>().Find(id);
                    if (ent == null)
                    {
                        return;
                    }

                    this._db.Set<T>().Remove(ent);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        }

        #endregion

        #region Select

        public virtual T GetById(int id)
        {
            try
            {
                return this._db.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        ///     Select Entities T in amount of numberOfObjects argument (Default 5)
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="numberOfObjects">Number of objects to return</param>
        /// <param name="orderType"></param>
        /// <returns>IEnumerable List of Entities</returns>
        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, int? pageNumber = null, int? numberOfObjects = null, OrderType orderType = OrderType.Ascending)
        {
            try
            {
                var result = this._db.Set<T>().Where(x => !x.IsDeleted).Where(filter ?? (x => true));
                result = orderType == OrderType.Ascending
                             ? result.OrderBy(x => x.Id)
                             : result.OrderByDescending(x => x.Id);
                if (pageNumber.HasValue && numberOfObjects.HasValue)
                {
                    return result.ToList().Skip(pageNumber.Value * numberOfObjects.Value).Take(numberOfObjects.Value);
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public virtual IEnumerable<T> GetAllDeleted(Expression<Func<T, bool>> filter = null, int? pageNumber = null, int? numberOfObjects = null, OrderType orderType = OrderType.Ascending)
        {
            try
            {
                var result = this._db.Set<T>().Where(x => x.IsDeleted).Where(filter ?? (x => true));
                result = orderType == OrderType.Ascending
                             ? result.OrderBy(x => x.Id)
                             : result.OrderByDescending(x => x.Id);
                if (pageNumber.HasValue && numberOfObjects.HasValue)
                {
                    return result.ToList().Skip(pageNumber.Value * numberOfObjects.Value).Take(numberOfObjects.Value);
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        #endregion
    }
}
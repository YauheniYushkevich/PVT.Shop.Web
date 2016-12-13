namespace PVT.Shop.Infrastructure.Repositories
{
    using System.Linq.Expressions;
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Enums;

    public interface IRepository<T> : IDisposable where T : BaseModel
    {

        void Save();

        #region CRUD        

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        void Restore(int id);

        void MowToHell(int id);

        #endregion

        #region Select

        T GetById(int id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, int? pageNumber = null, int? numberOfObjects = null, OrderType orderType = OrderType.Ascending);

        IEnumerable<T> GetAllDeleted(Expression<Func<T, bool>> filter = null,
                                     int? pageNumber = null,
                                     int? numberOfObjects = null,
                                     OrderType orderType = OrderType.Ascending);

        #endregion
    }
}
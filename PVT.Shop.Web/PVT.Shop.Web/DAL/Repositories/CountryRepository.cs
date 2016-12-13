namespace PVT.Shop.Web.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using Infrastructure.Common;
    using Infrastructure.Common.Enums;

    public class CountryRepository : Repository<Country>
    {
        private readonly ShopContext _db;

        public CountryRepository(ShopContext context) : base(context)
        {
            this._db = context;
        }

        ~CountryRepository()
        {
            this.Dispose(false);
        }

        public override void Update(Country country)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var temp = this._db.Countries.Find(country.Id);
                    if (temp != null)
                    {
                        this._db.Entry(temp).CurrentValues.SetValues(country);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine("\nCountryRepository_Update: " + ex.Message + "\n");
                }
            }
        }

        public override IEnumerable<Country> GetAll(Expression<Func<Country, bool>> filter = null, int? pageNumber = null, int? numberOfObjects = null, OrderType orderType = OrderType.Ascending)
        {
            var result = base.GetAll();

            if (result == null)
            {
                return null;
            }

            try
            {
                return orderType == OrderType.Ascending ? result.OrderBy(c => c.Name) : result.OrderByDescending(c => c.Name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nCountryRepository_GetAll: " + ex.Message + "\n");    
            }

            return result;
        }
    }
}

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

    public class AddressRepository : Repository<Address>
    {
        private readonly ShopContext _db;

        public AddressRepository(ShopContext context) : base(context)
        {
            this._db = context;
        }

        ~AddressRepository()
        {
            this.Dispose(false);
        }

        public override Address GetById(int id)
        {
            return this._db.Addresses.Include(a => a.Country).Where(a => a.Id == id).FirstOrDefault(a => a.Id == id);
        }

        public override IEnumerable<Address> GetAll(Expression<Func<Address, bool>> filter = null, int? pageNumber = null, int? numberOfObjects = null, OrderType orderType = OrderType.Ascending)
        {
            IEnumerable<Address> result = null;

            try
            {
                if (filter == null)
                {
                    if (pageNumber == null && numberOfObjects == null)
                    {
                        result = this._db.Addresses.Include(s => s.Country);
                    }
                    else
                    {
                        if (pageNumber == 0 || numberOfObjects == 0)
                        {
                            return null;
                        }

                        if (pageNumber != null)
                        {
                            if (numberOfObjects != null)
                            {
                                result = this._db.Addresses.Include(s => s.Country).Skip((pageNumber.Value - 1) * numberOfObjects.Value).Take(numberOfObjects.Value);
                            }                                
                        }                           
                    }
                }
                else
                {
                    if (pageNumber == null && numberOfObjects == null)
                    {
                        result = this._db.Addresses.Include(s => s.Country).Where(filter);
                    }
                    else
                    {
                        if (pageNumber == 0 || numberOfObjects == 0)
                        {
                            return null;
                        }

                        if (pageNumber != null)
                        {
                            if (numberOfObjects != null)
                            {
                                result = this._db.Addresses.Include(s => s.Country).Where(filter).Skip((pageNumber.Value - 1) * numberOfObjects.Value).Take(numberOfObjects.Value);
                            }
                        }                            
                    }
                }

                return orderType == OrderType.Ascending ? result.OrderBy(s => s.Id) : result.OrderByDescending(s => s.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nAddressRepository_GetAll: " + ex.Message + "\n");
                return result;
            }
        }

        public override void Update(Address address)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var temp = this._db.Addresses.Include(a => a.Country).FirstOrDefault(a => a.Id == address.Id);
                    if (temp != null)
                    {
                        this._db.Entry(temp.Country).CurrentValues.SetValues(address.Country);
                        this._db.Entry(temp).CurrentValues.SetValues(address);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine("\nAddressRepository_Update: " + ex.Message + "\n");
                }
            }
        }
    }
}
namespace PVT.Shop.Web.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using Authentication;
    using Infrastructure.Common;
    using Infrastructure.Common.Enums;

    public class UserRepository : Repository<User>
    {
        private readonly ShopContext _db;

        public UserRepository(ShopContext db) : base(db)
        {
            this._db = db;
        }

        [Flags]
        public enum Coinsidence
        {
            Nothing = 0x00,
            Login = 0x01,
            Password = 0x02
        }

        public override void Update(User user)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var temp = this.GetById(user.Id);
                    if (temp != null)
                    {
                        this._db.Entry(temp.Address.Country).CurrentValues.SetValues(user.Address.Country);
                        this._db.Entry(temp.Address).CurrentValues.SetValues(user.Address);
                        this._db.Entry(temp).CurrentValues.SetValues(user);
                        temp.PasswordConfirm = temp.Password;
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                }
            }
        }

        public override void Delete(int id)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    var user = this.GetById(id);

                    if (user != null)
                    {
                        this._db.Users.Remove(user);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine(ex);
                }
            }
        }

        public override User GetById(int id)
        {
            return this._db.Users.Include(a => a.Address)
                       .Include(a => a.Address.Country)
                       .FirstOrDefault(a => a.Id == id);
        }

        public override IEnumerable<User> GetAll(Expression<Func<User, bool>> filter = null, int? pageNumber = null, int? numberOfObjects = null, OrderType orderType = OrderType.Ascending)
        {
            IEnumerable<User> result = null;

            try
            {
                if (pageNumber == null && numberOfObjects == null)
                {
                    result = this._db.Users.Include(s => s.Address)
                                  .Include(s => s.Address.Country);
                }
                else
                {
                    if (pageNumber == 0 || numberOfObjects == 0)
                    {
                        return null;
                    }

                    result = this._db.Users.Include(s => s.Address)
                                  .Include(s => s.Address.Country)
                                  .Skip((pageNumber.Value - 1) * numberOfObjects.Value)
                                  .Take(numberOfObjects.Value);
                }

                return orderType == OrderType.Ascending
                           ? result.OrderBy(s => s.Login)
                           : result.OrderByDescending(s => s.Login);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return result;
            }
        }

        public User Login(string login, string pass)
        {
            return this._db.Users.FirstOrDefault(x => x.Login == login && x.Password == pass);
        }

        public bool IsExist(string login, string password, out Coinsidence typeOfСoincidence)
        {
            var user1 = this._db.Users.FirstOrDefault(x => x.Login == login);
            var user2 = this._db.Users.FirstOrDefault(x => x.Password == password);
            var user3 = this._db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user3 != null)
            {
                typeOfСoincidence = Coinsidence.Login | Coinsidence.Password;
                return true;
            }
            else
            {
                if (user1 != null)
                {
                    typeOfСoincidence = Coinsidence.Login;
                    return true;
                }

                if (user2 != null)
                {
                    typeOfСoincidence = Coinsidence.Password;
                    return true;
                }

                typeOfСoincidence = Coinsidence.Nothing;
                return false;
            }
        }

        public bool IsExistAnyAdmin(int id)
        {
            var user = this.GetById(id);
            if (user.Role == Role.Admin)
            {
                return this._db.Users.Any(u => u.Role == Role.Admin && u.Id != user.Id);
            }

            return true;
        }
    }
}

namespace PVT.Shop.Web.DAL.Repositories
{
    using System;
    using System.Linq;
    using Infrastructure.Common;
    using Infrastructure.Repositories;
    using System.Data.Entity.Infrastructure;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ShopContext _db;

        public OrderRepository(ShopContext db) : base(db)
        {
            this._db = db;
        }

        public override void Delete(int id)
        {
            var ent = this._db.Orders.FirstOrDefault(c => c.Id == id);
            this._db.Entry(ent).Collection(c => c.BasketProductID).Load();
            this._db.Orders.Remove(ent);
            this._db.SaveChanges();
         //   base.Delete(id);
        }

        public IEnumerable<Order> GetOrdersBySeller(int sellerId)
        {       
            string sqlquery = "Select * from Orders where Orders.Id in (";
            sqlquery += "Select o.Id from Orders o  inner Join BasketProductIDs b on o.Id = b.Order_Id ";
            sqlquery += " inner join Products p on b.ProductId = p.Id where p.CurrentUserId = " + sellerId + ")";

            try
            {
                var oderIds = _db.Orders.SqlQuery(sqlquery).ToList();
                return oderIds;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

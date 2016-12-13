namespace PVT.Shop.Web.Services
{
    using System.Collections.Generic;
    using DAL.Repositories;
    using Infrastructure.Common;
    using Infrastructure.Services;
    using System.Linq.Expressions;
    using System;

    public class OrderService : IOrderService
    {
        private readonly OrderRepository _repository;

        public OrderService(OrderRepository repository)
        {
            this._repository = repository;
        }

        public void AddOrder(Order order)
        {
            this._repository.Create(order);
        }

        public void DeleteOrder(int id)
        {
            this._repository.Delete(id);
        }

        public void UpdateOrder(Order order)
        {
            this._repository.Update(order);
        }

        public Order GetOrder(int id)
        {
            return this._repository.GetById(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return this._repository.GetAll();
        }

        public IEnumerable<Order> GetOrders(int id)
        {
            Expression<Func<Order, bool>> filter = p => p.UserId == id;
            return this._repository.GetAll(filter);
        }

        public IEnumerable<Order> GetOrders(int pageNumber, int numberOfObjects = 5)
        {
            return this._repository.GetAll();
        }

        public void SaveChanges()
        {
            this._repository.Save();
        }

        public IEnumerable<Order> GetOrdersBySel(int sellerId)
        {
            return this._repository.GetOrdersBySeller(sellerId);
        }


    }
}
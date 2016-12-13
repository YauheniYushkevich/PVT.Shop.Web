namespace PVT.Shop.Infrastructure.Services
{
    using System.Collections.Generic;
    using Common;

    public interface IOrderService
    {
        void AddOrder(Order order);

        void DeleteOrder(int id);

        void UpdateOrder(Order order);

        Order GetOrder(int id);

        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(int id);

        IEnumerable<Order> GetOrders(int pageNumber, int numberOfObjects = 5);
        IEnumerable<Order> GetOrdersBySel(int sellerId);

        void SaveChanges();
    }
}
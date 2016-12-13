namespace PVT.Shop.Infrastructure.Services
{
    using System.Collections.Generic;
    using Common;
    using Common.ViewModels;

    public interface IProductService
    {
        void AddProduct(Product product);

        void DeleteProduct(int id);

        void UpdateProduct(Product product);

        Product GetProduct(int id);

        IEnumerable<Product> GetProducts();

        CatalogViewModel GetProducts(int id);

        CatalogViewModel GetProductsByName(string name);

        IEnumerable<Product> GetProducts(string sortOrder, int userId);

        void SaveChanges();
    }
}
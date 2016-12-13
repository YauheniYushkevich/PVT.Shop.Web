namespace PVT.Shop.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DAL.Repositories;
    using Infrastructure.Common;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;

    public class ProductService : IProductService
    {
        private readonly Repository<Product> _repository;

        public ProductService(Repository<Product> repository)
        {
            this._repository = repository;
        }

        public void AddProduct(Product product)
        {
            this._repository.Create(product);
        }

        public void DeleteProduct(int id)
        {
            this._repository.Delete(id);
        }

        public void UpdateProduct(Product product)
        {
            this._repository.Update(product);
        }

        public Product GetProduct(int id)
        {
            return this._repository.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this._repository.GetAll();
        }

        public CatalogViewModel GetProducts(int id)
        {
            var query = this._repository.GetAll();
            var breadCrumb = "All";

            var vm = new CatalogViewModel();

            switch (id)
            {
                case 1:
                    query = query.Where(m => m.CurrentCategory.Parent.Name == "Electronics" && m.Display.Equals(true));
                    breadCrumb = "Electronics";
                    break;

                case 2:
                    query = query.Where(m => m.CurrentCategory.Name == "Cell-Phones" && m.Display.Equals(true));
                    breadCrumb = "Cell-Phones";
                    break;

                case 3:
                    query = query.Where(m => m.CurrentCategory.Name == "3G Modems" && m.Display.Equals(true));
                    breadCrumb = "3G Modems";
                    break;

                case 4:
                    query = query.Where(m => m.CurrentCategory.Name == "Notebooks" && m.Display.Equals(true));
                    breadCrumb = "Notebooks";
                    break;

                case 5:
                    query = query.Where(m => m.CurrentCategory.Parent.Name == "Appliances" && m.Display.Equals(true));
                    breadCrumb = "Appliances";
                    break;

                case 6:
                    query = query.Where(m => m.CurrentCategory.Name == "Refrigerators" && m.Display.Equals(true));
                    breadCrumb = "Refrigerators";
                    break;

                case 7:
                    query = query.Where(m => m.CurrentCategory.Name == "Coffee Machines" && m.Display.Equals(true));
                    breadCrumb = "Coffee Machines";
                    break;

                case 8:
                    query = query.Where(m => m.CurrentCategory.Name == "Vaccum Cleaners" && m.Display.Equals(true));
                    breadCrumb = "Vaccum Cleaners";
                    break;

                case 9:
                    query = query.Where(m => m.CurrentCategory.Parent.Name == "Building and repairing" && m.Display.Equals(true));
                    breadCrumb = "Building and repairing";
                    break;

                case 10:
                    query = query.Where(m => m.CurrentCategory.Name == "Drills" && m.Display.Equals(true));
                    breadCrumb = "Drills";
                    break;

                case 11:
                    query = query.Where(m => m.CurrentCategory.Name == "Vinyl Windows" && m.Display.Equals(true));
                    breadCrumb = "Vinyl Windows";
                    break;

                case 12:
                    query = query.Where(m => m.CurrentCategory.Name == "Toolboxes" && m.Display.Equals(true));
                    breadCrumb = "Toolboxes";
                    break;

                default:
                    query = this._repository.GetAll().Where(m => m.Display.Equals(true));
                    breadCrumb = "All";
                    break;
            }

            vm.BreadCrumb = breadCrumb;
            vm.Query = query;

            return vm;
        }

        public CatalogViewModel GetProductsByName(string name)
        {
            var query = this._repository.GetAll().Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.Display.Equals(true)).ToList();

            var breadCrumb = "Search Result";

            var vm = new CatalogViewModel
            {
                BreadCrumb = breadCrumb,
                Query = query
            };

            return vm;
        }

        public IEnumerable<Product> GetProducts(string sortOrder, int userId)
        {
            var query = this._repository.GetAll().Where(p => p.CurrentUser.Id == userId);

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                query = this._repository.GetAll();
            }

            switch (sortOrder)
            {
                case "name":
                    query = query.OrderBy(x => x.Name);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case "id":
                    query = query.OrderBy(x => x.Id);
                    break;
                case "id_desc":
                    query = query.OrderByDescending(x => x.Id);
                    break;
                case "count":
                    query = query.OrderBy(x => x.Count);
                    break;
                case "count_desc":
                    query = query.OrderByDescending(x => x.Count);
                    break;
                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(x => x.Price);
                    break;
                default:
                    break;
            }

            return query;
        }

        public void SaveChanges()
        {
            this._repository.Save();
        }
    }
}
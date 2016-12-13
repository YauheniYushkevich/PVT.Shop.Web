namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using PagedList;

    public class CategoryProductsViewModel
    {
        public Category Category { get; set; }

        public PagedList<Product> Products { get; set; } 

        public int CategoryProductsCount { get; set; }
    }
}
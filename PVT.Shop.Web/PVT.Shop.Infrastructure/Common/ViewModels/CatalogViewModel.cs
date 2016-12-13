namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using System.Collections.Generic;

    public class CatalogViewModel
    {
        public IEnumerable<Product> Query { get; set; }

        public string BreadCrumb { get; set; }
    }
}

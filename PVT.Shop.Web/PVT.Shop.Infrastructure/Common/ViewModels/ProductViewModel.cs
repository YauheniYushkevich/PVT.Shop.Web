namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel
    {
        [Required]
        public Product Current { get; set; }

        public IEnumerable<Category> CurrentCategories { get; set; }

        public IEnumerable<Storage> CurrentStorages { get; set; }

    }
}
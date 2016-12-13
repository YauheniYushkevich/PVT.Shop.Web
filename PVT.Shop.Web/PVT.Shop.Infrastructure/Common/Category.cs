namespace PVT.Shop.Infrastructure.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category name field is empty")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Category Parent { get; set; }

        public string Icon { get; set; }

        public List<Property> Properties { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Childs { get; set; }
    }
}
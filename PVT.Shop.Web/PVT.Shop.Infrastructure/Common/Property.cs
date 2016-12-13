namespace PVT.Shop.Infrastructure.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Property : BaseModel
    {
        /// <summary>
        ///     Property name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Property name field is empty")] 
        public string Name { get; set; }

        /// <summary>
        ///     Brief description of the property.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Category to which this property belongs
        /// </summary>
        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }
    }
}
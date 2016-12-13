namespace PVT.Shop.Infrastructure.Common
{
    using System.ComponentModel.DataAnnotations;

    public class PropertyValue : BaseModel
    {
        /// <summary>
        ///     Property which is assigned to this value
        /// </summary>
        public virtual Property Property { get; set; }

        /// <summary>
        ///     Product who owns this property value
        /// </summary>
        [Required]
        public virtual Product Product { get; set; }

        /// <summary>
        ///     The value of this product
        /// </summary>
        [Required]
        public string Value { get; set; }
    }
}
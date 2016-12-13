namespace PVT.Shop.Infrastructure.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    public class Product : BaseModel
    {
        /// <summary>
        ///     Product name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Product name is empty")]
        [DataType(DataType.Text)]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        /// <summary>
        ///     Product description
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Product description is empty")]
        [DataType(DataType.Text)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        /// <summary>
        ///     Seller information
        /// </summary>
        [Display(Name = "Product Seller")]
        public virtual User CurrentUser { get; set; }

        /// <summary>
        ///     Amount of goods sold
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Product amount is empty")]
        [Display(Name = "Product Amount")]
        public int Count { get; set; }

        /// <summary>
        ///     The price of the goods from the Seller
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Product price is empty")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        /// <summary>
        ///     The image of the goods from the Seller
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Product image is empty")]
        [DataType(DataType.Url, ErrorMessage = "Field Product image is not url")]
        [Display(Name = "Product Image")]
        public string Image { get; set; }

        /// <summary>
        ///     Product category. The place occupied by the product in the catalog
        /// </summary>
        [Display(Name = "Product Category")]
        public virtual Category CurrentCategory { get; set; }

        /// <summary>
        ///     Warehouse which stored goods
        /// </summary>
        [Display(Name = "Product Storage")]
        public virtual Storage CurrentStorage { get; set; }

        /// <summary>
        ///     Display in catalog value
        /// </summary>
        [Display(Name = "Display in Catalog?")]
        public bool Display { get; set; }

        [Required]
        [ForeignKey("CurrentCategory")]
        public int CurrentCategoryId { get; set; }

        [Required]
        [ForeignKey("CurrentStorage")]
        public int CurrentStorageId { get; set; }

        [Required]
        [ForeignKey("CurrentUser")]
        public int CurrentUserId { get; set; }
    }
}
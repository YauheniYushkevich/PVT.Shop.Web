namespace PVT.Shop.Infrastructure.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Country : BaseModel
    {
        [Display(Name = "Country name")]
        public string Name { get; set; }
    }
}

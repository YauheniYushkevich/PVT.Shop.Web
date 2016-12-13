namespace PVT.Shop.Infrastructure.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Storage : BaseModel
    {
        public Storage()
        {
            Address = new Address { Country = new Country() };
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Storage name field is empty")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Storage name field must contain from 4 to 20 characters")]
        [Display(Name = "Storage name")]
        [RegularExpression(@"^\w{1,}\s{0,1}\w{1,}\s{0,1}\w{1,}\s{0,1}$",
             ErrorMessage = @"Storage name field can contain characters, digits")]
        public string Name { get; set; }

        public Address Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number field is empty")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        [RegularExpression(@"\+{0,1}\s{0,1}[0-9]{1,3}\s{0,1}[0-9]{1,3}\s{0,1}[0-9]{1,3}\s{0,1}[0-9]{1,3}\s{0,1}$",
             ErrorMessage = @"Phone number filed can start with '+' and must contain only digits")]
        public string PhoneNumber { get; set; }
    }
}
namespace PVT.Shop.Infrastructure.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Address : BaseModel
    {
        public Country Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City field is empty")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-z,A-Z]{1,1}[a-z,A-Z]{2,}\s{0,1}$",
            ErrorMessage = "City field can contain only characters")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Postcode field is empty")]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[0-9]{5,10}\s{0,1}$", ErrorMessage = "Postcode can contain only digits")]
        public string Postcode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Street field is empty")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z, a-z, 0-9]{1,}[a-z,A-Z]{2,}\s{0,1}[a-z, 0-9]{1,}\s{0,1}$",
            ErrorMessage = "Street field can contain only characters, digits")]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Building number field is empty")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{1,5}\s{0,1}[\\\\, -]{0,1}\s{0,1}[0-9]{0,4}\s{0,2}$",
            ErrorMessage = @"Home number field can contain only characters, digits and '\'")]
        [Display(Name = "Building number")]
        public string HomeNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Apartment number field is empty")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{1,5}\s{0,1}[\\\\, -]{0,1}\s{0,1}[0-9]{0,4}\s{0,2}$",
            ErrorMessage = @"Apartment number field can contain only characters, digits and '\'")]
        [Display(Name = "Apartment number")]
        public string ApartmentNumber { get; set; }
    }
}
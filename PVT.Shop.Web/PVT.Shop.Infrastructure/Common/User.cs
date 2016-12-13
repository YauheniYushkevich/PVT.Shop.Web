using System;
using System.ComponentModel.DataAnnotations;

namespace PVT.Shop.Infrastructure.Common
{
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Gender
    {
        Man,
        Women
    }

    public class User : BaseModel
    {
        public User()
        {
            Address = new Address() { Country = new Country()};
        }

        [Display(Name = "Login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login field is empty")]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email field is empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password field is empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "These passwords don't match!")]
        [Display(Name = "Password Confirmation")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date, ErrorMessage = "Incorrect data in Birthday field")]
        public DateTime Birthday { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "User Role")]
        public Role Role { get; set; }

        public Address Address { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}

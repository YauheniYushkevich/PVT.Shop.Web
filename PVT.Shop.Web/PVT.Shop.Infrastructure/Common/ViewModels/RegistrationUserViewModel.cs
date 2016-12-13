namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RegistrationUserViewModel
    {
        public User CurrentUser { get; set; }

        public IEnumerable<Country> CurrentCountries { get; set; }

        public int CurrentCountryId { get; set; }
    }
}

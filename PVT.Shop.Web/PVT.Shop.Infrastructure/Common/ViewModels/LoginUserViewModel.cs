namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserViewModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

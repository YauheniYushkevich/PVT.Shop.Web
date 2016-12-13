namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePassViewModel
    {
        [Required]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "These passwords don't match!")]
        [Display(Name = "Password Confirmation")]
        public string ConfirmNewPassword { get; set; }
    }
}

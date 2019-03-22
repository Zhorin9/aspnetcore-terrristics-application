using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType =typeof(Resources.ModelValidation), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = "BadEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.ModelValidation), Name = "Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resources.ModelValidation), Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}

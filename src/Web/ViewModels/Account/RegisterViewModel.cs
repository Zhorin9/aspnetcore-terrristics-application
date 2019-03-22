using System.ComponentModel.DataAnnotations;
using Web.Resources;

namespace Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ModelValidation), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(ModelValidation), ErrorMessageResourceName = "BadEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelValidation), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(ModelValidation), Name = "Password")]
        [StringLength(100, ErrorMessageResourceType = typeof(ModelValidation), ErrorMessageResourceName = "PasswordLength", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(ModelValidation), Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(ModelValidation), ErrorMessageResourceName = "BadConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}

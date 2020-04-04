using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.Authentications
{
    public class LoginApiModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
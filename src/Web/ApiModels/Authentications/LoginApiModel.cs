using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.Authentications
{
    public class LoginApiModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
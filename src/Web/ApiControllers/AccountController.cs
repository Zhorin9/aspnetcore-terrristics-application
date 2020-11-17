using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auth;
using Auth.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web.ApiModels.Authentications;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Web.ApiControllers
{
    [EnableCors("AllowOrigin")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {message = "Email or password is incorrect"});
            }

            ApplicationUser user = await FindByEmailAsync(model);

            if (user == null)
            {
                return BadRequest(new {message = "Email or password is incorrect"});
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest(new {message = "Email or password is incorrect"});
            }

            Claim[] claims = CreateClaims(user);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: credentials
            );
            var results = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };

            return Ok(results);
        }

        private async Task<ApplicationUser> FindByEmailAsync(LoginApiModel model)
        {
            return await _userManager.FindByEmailAsync(model.Email);
        }

        private static Claim[] CreateClaims(ApplicationUser user)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
        }
    }
}
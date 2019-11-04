using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels.UserWindows;

namespace Microsoft.eShopWeb.Web.Controllers.Api
{
    public class UserWindowController: BaseApiController
    {
        public UserWindowController(IMapper mapper) : base(mapper)
        {
        }

        [HttpPost]
        public IActionResult Create(UserWindowApiModel userWindow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Formularz został niepoprawnie wypełniony. Spróbuj ponownie");
            }

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok();
            
        }
    }
}
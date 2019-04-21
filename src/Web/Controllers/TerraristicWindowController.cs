using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TerraristicWindowsController : Controller
    {
        private ITerraristicWindowRepository _repository;
        private ILogger<TerraristicWindowsController> _logger;

        public TerraristicWindowsController(ITerraristicWindowRepository repository, ILogger<TerraristicWindowsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetWindows()
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return Ok(await _repository.GetByUserIdWithItemsAsync(userId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get windows: {ex}");
                return BadRequest("Problem with extracting windows");
            }
        }
    }
}
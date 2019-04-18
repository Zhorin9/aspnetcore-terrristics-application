using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("api/[Controller]")]
    public class TerraristicWindowsController : Controller
    {
        private IAsyncAppRepository<TerraristicWindow> _repository;
        private ILogger<TerraristicWindowsController> _logger;

        public TerraristicWindowsController(IAsyncAppRepository<TerraristicWindow> repository, ILogger<TerraristicWindowsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetWindows()
        {
            try
            {
                return Ok(_repository.ListAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get windows: {ex}");
                return BadRequest("Problem with extracting windows");
            }
        }
    }
}
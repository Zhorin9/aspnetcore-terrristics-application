using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Web.Controllers.Api;

namespace Web.ApiControllers.Common
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DictionaryApiController : BaseApiController
    {
        private readonly ISensorKindRepository _sensorKindRepository;

        public DictionaryApiController(ISensorKindRepository sensorKindRepository)
        {
            _sensorKindRepository = sensorKindRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSensors()
        {
            IEnumerable<SensorKind> sensors = await _sensorKindRepository.ListAllAsync();

            
            return Ok(sensors);
        }
    }
}
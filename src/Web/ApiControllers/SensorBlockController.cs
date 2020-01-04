using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels.SensorBlocks;

namespace Web.ApiControllers
{
    public class SensorBlockController : BaseApiController
    {
        private readonly ISensorBlockRepository _sensorBlockRepository;

        public SensorBlockController(IMapper mapper, ISensorBlockRepository sensorBlockRepository) : base(mapper)
        {
            _sensorBlockRepository = sensorBlockRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SensorBlockApiModel sensorToCreate)
        {
            
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int windowId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<SensorBlock> sensorBlocks = await _sensorBlockRepository.GetAsync(windowId, userId);
            List<SensorBlockApiModel> sensorBlockResponse = Mapper.Map<List<SensorBlock>, List<SensorBlockApiModel>>(sensorBlocks);

            return Ok(new JsonResult(sensorBlockResponse));
        }
    }
}
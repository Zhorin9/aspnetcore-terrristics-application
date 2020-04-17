using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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
        public IActionResult Create([FromBody] SensorBlockApiModel sensorToCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Formularz został niepoprawnie wypełniony. Spróbuj ponownie");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newSensorBlock = new SensorBlock
            {
                Name = sensorToCreate.Name,
                Description = sensorToCreate.Description,
                UserId = userId,
                ParentWindowId = sensorToCreate.WindowId,
                SensorKindId = sensorToCreate.SensorKind.SensorKindId
            };

            int result = _sensorBlockRepository.AddAsync(newSensorBlock).Result;

            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sensorBlockId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SensorBlock sensorBlock = await _sensorBlockRepository.GetAsync(sensorBlockId);

            if (sensorBlock == null)
            {
                return NotFound("Nie znaleziono odpowiedniego sensora");
            }

            if (sensorBlock.UserId != userId)
            {
                return Unauthorized();
            }

            SensorBlockApiModel sensorBlockResponse = Mapper.Map<SensorBlockApiModel>(sensorBlock);
            return Ok(sensorBlockResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int windowId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<SensorBlock> sensorBlocks = await _sensorBlockRepository.GetAsync(windowId, userId);
            List<SensorBlockApiModel> sensorBlockResponse = Mapper.Map<List<SensorBlockApiModel>>(sensorBlocks);

            return Ok(new JsonResult(sensorBlockResponse));
        }
    }
}
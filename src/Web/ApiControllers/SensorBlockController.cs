using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
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
        public async Task<IActionResult> Create([FromBody] SensorBlockApiModel sensorToCreate)
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

            int result = await CreateSensorBlockDependsOnType(sensorToCreate, newSensorBlock);

            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] SensorBlockApiModel sensorBlockApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Formularz został niepoprawnie wypełniony. Spróbuj ponownie");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sensorBlockToUpdate = new SensorBlock
            {
                Id = sensorBlockApiModel.Id,
                Name = sensorBlockApiModel.Name,
                Description = sensorBlockApiModel.Description
            };

            int result = await _sensorBlockRepository.UpdateBaseParameters(sensorBlockToUpdate, userId);

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
        
        private async Task<int> CreateSensorBlockDependsOnType(SensorBlockApiModel sensorToCreate, SensorBlock newSensorBlock)
        {
            if (sensorToCreate.SensorKind.Type == SensorTypeEnum.Input)
            {
                return await _sensorBlockRepository.AddAsync(newSensorBlock);
            }

            newSensorBlock.OutputData = new OutputSensorData
            {
                Value = "",
                State = false
            };
            return await _sensorBlockRepository.CreateWithOutputData(newSensorBlock);
        }
    }
}
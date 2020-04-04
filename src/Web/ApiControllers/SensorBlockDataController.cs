using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels.SensorBlockData;

namespace Web.ApiControllers
{
    public class SensorBlockDataController : BaseApiController
    {
        private readonly IInputBlockDataRepository _inputBlockDataRepository;
        private readonly ISensorBlockRepository _sensorBlockRepository;
        private readonly ITerraristicWindowRepository _terraristicWindowRepository;

        public SensorBlockDataController(IMapper mapper, IInputBlockDataRepository inputBlockDataRepository, ISensorBlockRepository sensorBlockRepository, ITerraristicWindowRepository terraristicWindowRepository) : base(mapper)
        {
            _inputBlockDataRepository = inputBlockDataRepository;
            _sensorBlockRepository = sensorBlockRepository;
            _terraristicWindowRepository = terraristicWindowRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int sensorBlockId)
        {
            List<InputSensorData> sensorBlockData = await _inputBlockDataRepository.GetData(sensorBlockId);
            List<InputSensorBlockDataApiModel> sensorBlockDataApis = Mapper.Map<List<InputSensorBlockDataApiModel>>(sensorBlockData);

            return Ok(sensorBlockDataApis);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputSensorBlockDataApiModel blockDataApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isValid = _terraristicWindowRepository.IsValidInputData(blockDataApiModel.WindowApiKey, blockDataApiModel.SensorBlockId);
            if (isValid)
            {
                return Unauthorized();
            }

            var sensorData = new InputSensorData
            {
                CreationDate = blockDataApiModel.CreationDate,
                SensorBlockId = blockDataApiModel.SensorBlockId,
                Value = blockDataApiModel.Value
            };
            
            
        }
    }
}
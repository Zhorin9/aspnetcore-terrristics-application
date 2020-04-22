using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels.SensorBlockData;

namespace Web.ApiControllers
{
    public class SensorBlockDataController : BaseApiController
    {
        private readonly IInputBlockDataRepository _inputBlockDataRepository;
        private readonly IOutputBlockDataRepository _outputBlockDataRepository;

        public SensorBlockDataController(IMapper mapper, IInputBlockDataRepository inputBlockDataRepository, IOutputBlockDataRepository outputBlockDataRepository) : base(mapper)
        {
            _inputBlockDataRepository = inputBlockDataRepository;
            _outputBlockDataRepository = outputBlockDataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int sensorBlockId)
        {
            List<InputSensorData> sensorBlockData = await _inputBlockDataRepository.GetData(sensorBlockId);
            List<InputSensorBlockDataApiModel> sensorBlockDataApis = Mapper.Map<List<InputSensorBlockDataApiModel>>(sensorBlockData);

            return Ok(sensorBlockDataApis);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] InputSensorBlockDataApiModel blockDataApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sensorData = new InputSensorData
            {
                CreationDate = blockDataApiModel.CreationDate,
                SensorBlockId = blockDataApiModel.SensorBlockId,
                Value = blockDataApiModel.Value
            };

            var result = _inputBlockDataRepository.Add(blockDataApiModel.WindowApiKey, blockDataApiModel.SensorBlockId, sensorData);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrUpdate([FromBody] OutputSensorDataApiModel blockDataApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var outputSensorData = new OutputSensorData
            {
                SensorBlockId = blockDataApiModel.SensorBlockId,
                State = blockDataApiModel.State,
                Value = blockDataApiModel.Value
            };

            var result = await _outputBlockDataRepository.Update(outputSensorData);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOutputState(int sensorBlockId)
        {
            OutputSensorData outputSensorData = await _outputBlockDataRepository.Get(sensorBlockId);

            if (outputSensorData == null)
            {
                return BadRequest("Problem with sensor status readout");
            }
            
            return Ok(outputSensorData.State);
        }
    }
}
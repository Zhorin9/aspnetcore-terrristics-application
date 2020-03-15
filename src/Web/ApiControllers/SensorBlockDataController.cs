using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels.SensorBlocks;

namespace Web.ApiControllers
{
    public class SensorBlockDataController : BaseApiController
    {
        private readonly IInputBlockDataRepository _inputBlockDataRepository;

        private readonly IAppLogger<SensorBlockDataController> _logger;

        public SensorBlockDataController(IMapper mapper, IInputBlockDataRepository inputBlockDataRepository, IAppLogger<SensorBlockDataController> appLogger) : base(mapper)
        {
            _inputBlockDataRepository = inputBlockDataRepository;
            _logger = appLogger;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int sensorBlockId)
        {
            try
            {
                List<InputSensorData> sensorBlockData = await _inputBlockDataRepository.GetData(sensorBlockId);
                List<InputSensorBlockDataApiModel> sensorBlockDataApis = Mapper.Map<List<InputSensorBlockDataApiModel>>(sensorBlockData);

                return Ok(sensorBlockDataApis);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return BadRequest();
        }
    }
}
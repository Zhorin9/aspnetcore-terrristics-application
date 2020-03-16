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

        public SensorBlockDataController(IMapper mapper, IInputBlockDataRepository inputBlockDataRepository) : base(mapper)
        {
            _inputBlockDataRepository = inputBlockDataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int sensorBlockId)
        {
            List<InputSensorData> sensorBlockData = await _inputBlockDataRepository.GetData(sensorBlockId);
            List<InputSensorBlockDataApiModel> sensorBlockDataApis = Mapper.Map<List<InputSensorBlockDataApiModel>>(sensorBlockData);

            return Ok(sensorBlockDataApis);
        }
    }
}
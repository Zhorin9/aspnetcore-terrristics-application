using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels;

namespace Web.ApiControllers.Common
{
    public class DictionaryController : BaseApiController
    {
        private readonly ISensorKindRepository _sensorKindRepository;

        public DictionaryController(ISensorKindRepository sensorKindRepository, IMapper mapper) : base(mapper)
        {
            _sensorKindRepository = sensorKindRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSensorKinds()
        {
            IEnumerable<SensorKind> sensors = await _sensorKindRepository.ListAllAsync();
            List<SensorKindApiModel> sensorKindViewModels = Mapper.Map<IEnumerable<SensorKind>, List<SensorKindApiModel>>(sensors);

            return Ok(sensorKindViewModels);
        }
    }
}
using AppCore.Interfaces;
using AutoMapper;

namespace Web.ApiControllers
{
    public class SensorBlockApiController : BaseApiController
    {
        private readonly ISensorBlockRepository _sensorBlockRepository;

        public SensorBlockApiController(IMapper mapper, ISensorBlockRepository sensorBlockRepository) : base(mapper)
        {
            _sensorBlockRepository = sensorBlockRepository;
        }
    }
}
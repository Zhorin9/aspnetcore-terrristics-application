using System.Threading.Tasks;
using Application.SensorKinds.Queries.GetSensorKindList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers.Common
{
    public class DictionaryController : BaseApiController
    {
        private readonly IMediator _mediator;
        
        public DictionaryController(IMapper mapper, IMediator mediator) : base(mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSensorKinds()
        {
            var ams = await _mediator.Send(new GetSensorKindListQuery());

            return Ok(ams);
        }
    }
}
using System.Threading.Tasks;
using Application.SensorBlocks.Commands.CreateSensorBlock;
using Application.SensorBlocks.Commands.UpdateSensorBlock;
using Application.SensorBlocks.Queries.GetSensorBlockDetail;
using Application.SensorBlocks.Queries.GetSensorBlockList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    public class SensorBlockController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SensorBlockController(IMediator mediator, IMapper mapper) : base(mapper)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSensorBlockCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateSensorBlockCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<SensorBlockDetailAm>> Get(int sensorBlockId)
        {
            var am = await _mediator.Send(new GetSensorBlockDetailQuery {Id = sensorBlockId});

            return Ok(am);
        }

        [HttpGet]
        public async Task<ActionResult<SensorBlockListAm>> GetList(int windowId)
        {
            var am = await _mediator.Send(new GetSensorBlockListQuery {WindowId = windowId});

            return Ok(am);
        }
    }
}
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
        public SensorBlockController(IMediator mediator, IMapper mapper) : base(mapper, mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSensorBlockCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateSensorBlockCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<SensorBlockDetailAm>> Get(int sensorBlockId)
        {
            SensorBlockDetailAm am = await Mediator.Send(new GetSensorBlockDetailQuery {Id = sensorBlockId});

            return Ok(am);
        }

        [HttpGet]
        public async Task<ActionResult<SensorBlockListAm>> GetList(int windowId)
        {
            SensorBlockListAm am = await Mediator.Send(new GetSensorBlockListQuery {WindowId = windowId});

            return Ok(am);
        }
    }
}
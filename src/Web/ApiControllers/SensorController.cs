using System.Threading.Tasks;
using Application.SensorBlocks.Commands.UpdateSensorBlock;
using Application.SensorBlocks.Queries.GetSensorBlockDetail;
using Application.Sensors.Commands.CreateSensor;
using Application.Sensors.Queries.GetSensorBlockList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    public class SensorController : BaseApiController
    {
        public SensorController(IMediator mediator, IMapper mapper) : base(mapper, mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateSensorCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSensorCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("get")]
        public async Task<ActionResult<SensorBlockDetailAm>> Get(int id)
        {
            SensorBlockDetailAm am = await Mediator.Send(new GetSensorBlockDetailQuery {Id = id});

            return Ok(am);
        }

        [HttpGet("getList")]
        public async Task<ActionResult<SensorBlockListAm>> GetList(int windowId)
        {
            SensorBlockListAm am = await Mediator.Send(new GetSensorBlockListQuery {WindowId = windowId});

            return Ok(am);
        }
    }
}
using System.Threading.Tasks;
using Application.SensorBlocks.Queries.GetSensorBlockDetail;
using Application.Sensors.Commands.CreateSensor;
using Application.Sensors.Commands.UpdateSensor;
using Application.Sensors.Queries.GetSensorDetail;
using Application.Sensors.Queries.GetSensorList;
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
    
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateSensorCommand command)
        {
            int result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult<int>> Update([FromBody] UpdateSensorCommand command)
        {
            int result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<SensorDetailAm>> Get(int id)
        {
            SensorDetailAm am = await Mediator.Send(new GetSensorDetailQuery {Id = id});

            return Ok(am);
        }

        [HttpGet("getList")]
        public async Task<ActionResult<SensorListAm>> GetList(int windowId)
        {
            SensorListAm am = await Mediator.Send(new GetSensorListQuery {WindowId = windowId});

            return Ok(am);
        }
    }
}
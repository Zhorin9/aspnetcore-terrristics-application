using System.Threading.Tasks;
using Application.InputSensorDatas.Commands.CreateInputData;
using Application.InputSensorDatas.Commands.DeleteInputAllData;
using Application.InputSensors.Queries.GetInputSensorDataList;
using Application.OutputSensorDatas.Commands.UpsertOutputSensorData;
using Application.OutputSensorDatas.Queries.GetOutputSensorData;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    public class SensorBlockDataController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SensorBlockDataController(IMapper mapper, IMediator mediator) : base(mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<InputSensorDataListAm>> GetList(int sensorBlockId)
        {
            var am = await _mediator.Send(new GetInputSensorDataListQuery {SensorBlockId = sensorBlockId});

            return Ok(am);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateInputData([FromBody] CreateInputDataCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAllInputData([FromBody] int sensorBlockId)
        {
            await _mediator.Send(new DeleteInputAllDataCommand {SensorBlockId = sensorBlockId});

            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrUpdate([FromBody] UpsertOutputSensorDataCommand blockDataApiModel)
        {
            await _mediator.Send(new UpsertOutputSensorDataCommand {SensorBlockId = blockDataApiModel.SensorBlockId});

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetOutputState(int sensorBlockId)
        {
            var am = await _mediator.Send(new GetOutputSensorDataQuery {SensorBlockId = sensorBlockId});

            return Ok(am.State);
        }
    }
}
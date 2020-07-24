using System.Threading.Tasks;
using Application.InputSensorDatas.Commands.CreateInputData;
using Application.InputSensorDatas.Commands.DeleteInputAllData;
using Application.InputSensorDatas.Queries.GetInputSensorDataList;
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
        public SensorBlockDataController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<InputSensorDataListAm>> GetList(int sensorBlockId)
        {
            var am = await Mediator.Send(new GetInputSensorDataListQuery {SensorBlockId = sensorBlockId});

            return Ok(am);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateInputData([FromBody] CreateInputDataCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAllInputData([FromBody] int sensorBlockId)
        {
            await Mediator.Send(new DeleteInputAllDataCommand {SensorBlockId = sensorBlockId});

            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrUpdate([FromBody] UpsertOutputSensorDataCommand blockDataApiModel)
        {
            await Mediator.Send(new UpsertOutputSensorDataCommand {SensorBlockId = blockDataApiModel.SensorBlockId});

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetOutputState(int sensorBlockId)
        {
            var am = await Mediator.Send(new GetOutputSensorDataQuery {SensorBlockId = sensorBlockId});

            return Ok(am.State);
        }
    }
}
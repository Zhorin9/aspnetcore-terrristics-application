using System.Threading.Tasks;
using Application.ControlSensors.Commands.UpsertControlSensor;
using Application.ControlSensors.Queries.GetControlSensor;
using Application.InputSensorDatas.Commands.CreateInputData;
using Application.InputSensorDatas.Commands.DeleteInputAllData;
using Application.InputSensorDatas.Queries.GetInputSensorDataList;
using Application.ReadSensorData.Commands.DeleteInputAllData;
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
            await Mediator.Send(new DeleteAllSensorReadData {SensorBlockId = sensorBlockId});

            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrUpdate([FromBody] UpsertControlSensorCommand blockApiModel)
        {
            await Mediator.Send(new UpsertControlSensorCommand {SensorBlockId = blockApiModel.SensorBlockId});

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetOutputState(int sensorBlockId)
        {
            var am = await Mediator.Send(new GetControlSensorQuery {SensorBlockId = sensorBlockId});

            return Ok(am.State);
        }
    }
}
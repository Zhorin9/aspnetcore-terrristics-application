using System.Threading.Tasks;
using Application.Terrariums.Commands.CreateTerrarium;
using Application.Terrariums.Commands.DeleteTerrarium;
using Application.Terrariums.Commands.UpdateTerrarium;
using Application.Terrariums.Queries.GetTerrarariumList;
using Application.Terrariums.Queries.GetTerrariumDetail;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    public class TerrariumController : BaseApiController
    {
        public TerrariumController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<TerrariumDetailAm>> Get([FromBody] int id)
        {
            TerrariumDetailAm am = await Mediator.Send(new GetTerrariumDetailQuery {Id = id});

            return Ok(new JsonResult(am));
        }

        [HttpGet]
        public async Task<ActionResult<TerrariumListAm>> GetList()
        {
            var am = await Mediator.Send(new GetTerrariumListQuery());

            return Ok(am);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTerrariumCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTerrariumCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await Mediator.Send(new DeleteTerrariumCommand {Id = id});

            return NoContent();
        }
    }
}
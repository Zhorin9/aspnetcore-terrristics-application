using System.Threading.Tasks;
using Application.TerraristicWindows.Commands.CreateTerraristicsWindow;
using Application.TerraristicWindows.Commands.DeleteTerraristicsWindow;
using Application.TerraristicWindows.Commands.UpdateTerraristicsWindow;
using Application.TerraristicWindows.Queries.GetTerraristicsWindowDetail;
using Application.TerraristicWindows.Queries.GetTerraristicsWindowList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    public class TerraristicsWindowController : BaseApiController
    {
        public TerraristicsWindowController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<TerraristicsWindowDetailAm>> Get([FromBody] int id)
        {
            TerraristicsWindowDetailAm am = await Mediator.Send(new GetTerraristicsWindowDetailQuery {Id = id});

            return Ok(new JsonResult(am));
        }

        [HttpGet]
        public async Task<ActionResult<TerraristicsWindowListAm>> GetList()
        {
            var am = await Mediator.Send(new GetTerraristicsWindowListQuery());

            return Ok(am);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTerraristicsWindowCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTerraristicsWindowCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await Mediator.Send(new DeleteTerraristicsWindowCommand {Id = id});

            return NoContent();
        }
    }
}
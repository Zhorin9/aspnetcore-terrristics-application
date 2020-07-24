using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.SensorKinds.Queries.GetSensorKindList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers.Common
{
    public class DictionaryController : BaseApiController
    {
        public DictionaryController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetSensorKinds()
        {
            List<SensorKindAm> ams = await Mediator.Send(new GetSensorKindListQuery());

            return Ok(ams);
        }
    }
}
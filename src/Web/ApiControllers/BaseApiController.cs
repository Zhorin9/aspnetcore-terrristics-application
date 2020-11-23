using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    [Authorize]
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper Mapper;
        protected readonly IMediator Mediator;

        public BaseApiController(IMapper mapper, IMediator mediator)
        {
            Mapper = mapper;
            Mediator = mediator;
        }
    }
}
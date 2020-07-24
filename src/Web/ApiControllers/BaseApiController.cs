using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
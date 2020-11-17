using System.Threading.Tasks;
using Application.User.Queries.GetUserWithToken;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.ApiControllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpPost("createToken")]
        [AllowAnonymous]
        public async Task<ActionResult<UserWithTokenAm>> CreateToken([FromBody] GetUserWithTokenQuery query)
        {
            UserWithTokenAm am = await Mediator.Send(query);

            return Ok(am);
        }
    }
}
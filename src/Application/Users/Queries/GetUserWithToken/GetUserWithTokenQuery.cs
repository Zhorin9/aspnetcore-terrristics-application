using MediatR;

namespace Application.Users.Queries.GetUserWithToken
{
    public class GetUserWithTokenQuery : IRequest<UserWithTokenAm>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
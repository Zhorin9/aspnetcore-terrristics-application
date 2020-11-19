using FluentValidation;

namespace Application.Users.Queries.GetUserWithToken
{
    public class GetUserWithTokenQueryValidation : AbstractValidator<GetUserWithTokenQuery>
    {
        public GetUserWithTokenQueryValidation()
        {
            RuleFor(query => query.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(query => query.Password).NotNull().NotEmpty();
        }
    }
}
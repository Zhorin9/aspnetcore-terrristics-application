using FluentValidation;

namespace Application.Terrariums.Queries.GetTerrariumDetail
{
    public class GetTerrariumDetailQueryValidator : AbstractValidator<GetTerrariumDetailQuery>
    {
        public GetTerrariumDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().GreaterThan(0);
        }
    }
}
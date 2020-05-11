using FluentValidation;

namespace Application.TerraristicWindows.Queries.GetTerraristicsWindowDetail
{
    public class GetTerraristicsWindowDetailQueryValidator : AbstractValidator<GetTerraristicsWindowDetailQuery>
    {
        public GetTerraristicsWindowDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().GreaterThan(0);
        }
    }
}
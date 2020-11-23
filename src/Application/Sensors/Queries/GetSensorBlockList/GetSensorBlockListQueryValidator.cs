using FluentValidation;

namespace Application.SensorBlocks.Queries.GetSensorBlockList
{
    public class GetSensorBlockListQueryValidator : AbstractValidator<GetSensorBlockListQuery>
    {
        public GetSensorBlockListQueryValidator()
        {
            RuleFor(v => v.WindowId).NotEmpty().GreaterThan(0);
        }
    }
}
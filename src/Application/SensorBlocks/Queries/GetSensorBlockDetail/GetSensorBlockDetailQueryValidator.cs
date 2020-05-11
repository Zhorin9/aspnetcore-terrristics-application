using FluentValidation;

namespace Application.SensorBlocks.Queries.GetSensorBlockDetail
{
    public class GetSensorBlockDetailQueryValidator: AbstractValidator<GetSensorBlockDetailQuery>
    {
        public GetSensorBlockDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().GreaterThan(0);
        }
    }
}
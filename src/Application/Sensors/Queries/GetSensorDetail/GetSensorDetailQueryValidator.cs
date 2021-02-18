using FluentValidation;

namespace Application.Sensors.Queries.GetSensorDetail
{
    public class GetSensorDetailQueryValidator: AbstractValidator<GetSensorDetailQuery>
    {
        public GetSensorDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().GreaterThan(0);
        }
    }
}
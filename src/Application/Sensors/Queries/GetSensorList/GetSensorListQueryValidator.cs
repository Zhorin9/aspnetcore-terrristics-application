using FluentValidation;

namespace Application.Sensors.Queries.GetSensorList
{
    public class GetSensorListQueryValidator : AbstractValidator<GetSensorListQuery>
    {
        public GetSensorListQueryValidator()
        {
            RuleFor(v => v.WindowId).NotEmpty().GreaterThan(0);
        }
    }
}
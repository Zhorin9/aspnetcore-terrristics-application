using FluentValidation;

namespace Application.ControlSensors.Queries.GetControlSensor
{
    public class GetControlSensorQueryValidator : AbstractValidator<GetControlSensorQuery>
    {
        public GetControlSensorQueryValidator()
        {
            RuleFor(x => x.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
using FluentValidation;

namespace Application.Sensors.Commands.CreateSensor
{
    public class CreateSensorCommandValidator : AbstractValidator<CreateSensorCommand>
    {
        public CreateSensorCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(250);
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.WindowId).NotNull().GreaterThan(0);
            RuleFor(x => x.SensorKind).NotNull();
        }
    }
}
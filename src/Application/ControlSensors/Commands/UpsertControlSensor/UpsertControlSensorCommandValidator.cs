using FluentValidation;

namespace Application.ControlSensors.Commands.UpsertControlSensor
{
    public class UpsertControlSensorCommandValidator : AbstractValidator<UpsertControlSensorCommand>
    {
        public UpsertControlSensorCommandValidator()
        {
            RuleFor(command => command.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
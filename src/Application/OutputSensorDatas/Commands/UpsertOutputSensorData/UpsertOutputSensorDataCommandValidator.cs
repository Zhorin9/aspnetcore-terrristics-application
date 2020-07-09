using FluentValidation;

namespace Application.OutputSensorDatas.Commands.UpsertOutputSensorData
{
    public class UpsertOutputSensorDataCommandValidator : AbstractValidator<UpsertOutputSensorDataCommand>
    {
        public UpsertOutputSensorDataCommandValidator()
        {
            RuleFor(command => command.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
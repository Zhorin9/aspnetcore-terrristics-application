using Application.Terrariums.Commands.UpdateTerrarium;
using FluentValidation;

namespace Application.Sensors.Commands.UpdateSensor
{
    public class UpdateSensorCommandValidator : AbstractValidator<UpdateTerrariumCommand>
    {
        public UpdateSensorCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MaximumLength(250);
            RuleFor(x => x.Description).MaximumLength(300);
        }
    }
}
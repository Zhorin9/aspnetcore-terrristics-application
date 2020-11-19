using Application.Terrariums.Commands.UpdateTerrarium;
using FluentValidation;

namespace Application.SensorBlocks.Commands.UpdateSensorBlock
{
    public class UpdateSensorBlockCommandValidator : AbstractValidator<UpdateTerrariumCommand>
    {
        public UpdateSensorBlockCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MaximumLength(250);
            RuleFor(x => x.Description).MaximumLength(300);
        }
    }
}
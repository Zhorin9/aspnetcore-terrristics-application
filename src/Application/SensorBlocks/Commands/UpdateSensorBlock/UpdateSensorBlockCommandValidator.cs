using Application.TerraristicWindows.Commands.UpdateTerraristicsWindow;
using FluentValidation;

namespace Application.SensorBlocks.Commands.UpdateSensorBlock
{
    public class UpdateSensorBlockCommandValidator : AbstractValidator<UpdateTerraristicsWindowCommand>
    {
        public UpdateSensorBlockCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MaximumLength(250);
            RuleFor(x => x.Description).MaximumLength(300);
        }
    }
}
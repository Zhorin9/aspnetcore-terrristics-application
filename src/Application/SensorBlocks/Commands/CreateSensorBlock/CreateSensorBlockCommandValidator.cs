using FluentValidation;

namespace Application.SensorBlocks.Commands.CreateSensorBlock
{
    public class CreateSensorBlockCommandValidator : AbstractValidator<CreateSensorBlockCommand>
    {
        public CreateSensorBlockCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MaximumLength(250);
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.WindowId).NotNull().GreaterThan(0);
            RuleFor(x => x.SensorKind).NotNull();
        }
    }
}
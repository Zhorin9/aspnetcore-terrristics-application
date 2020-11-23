using FluentValidation;

namespace Application.Terrariums.Commands.CreateTerrarium
{
    public class CreateTerrariumCommandValidator : AbstractValidator<CreateTerrariumCommand>
    {
        public CreateTerrariumCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Description).MaximumLength(200);
        }
    }
}
using FluentValidation;

namespace Application.TerraristicWindows.Commands.CreateTerraristicsWindow
{
    public class CreateTerraristicsWindowCommandValidator : AbstractValidator<CreateTerraristicsWindowCommand>
    {
        public CreateTerraristicsWindowCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Description).MaximumLength(200);
        }
    }
}
using FluentValidation;

namespace Application.TerraristicWindows.Commands.UpdateTerraristicsWindow
{
    public class UpdateTerraristicsWindowCommandValidator : AbstractValidator<UpdateTerraristicsWindowCommand>
    {
        public UpdateTerraristicsWindowCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Description).MaximumLength(200);
        }
    }
}
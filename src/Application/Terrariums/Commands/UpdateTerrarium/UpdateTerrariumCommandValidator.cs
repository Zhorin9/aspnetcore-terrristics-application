using FluentValidation;

namespace Application.Terrariums.Commands.UpdateTerrarium
{
    public class UpdateTerrariumCommandValidator : AbstractValidator<UpdateTerrariumCommand>
    {
        public UpdateTerrariumCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Description).MaximumLength(200);
        }
    }
}
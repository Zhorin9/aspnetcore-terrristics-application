using FluentValidation;

namespace Application.InputSensorDatas.Commands.DeleteInputAllData
{
    public class DeleteInputAllDataCommandValidator : AbstractValidator<DeleteInputAllDataCommand>
    {
        public DeleteInputAllDataCommandValidator()
        {
            RuleFor(v => v.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
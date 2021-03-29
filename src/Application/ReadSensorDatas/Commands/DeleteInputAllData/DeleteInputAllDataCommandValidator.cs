using Application.ReadSensorData.Commands.DeleteInputAllData;
using FluentValidation;

namespace Application.InputSensorDatas.Commands.DeleteInputAllData
{
    public class DeleteInputAllDataCommandValidator : AbstractValidator<DeleteAllSensorReadData>
    {
        public DeleteInputAllDataCommandValidator()
        {
            RuleFor(v => v.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
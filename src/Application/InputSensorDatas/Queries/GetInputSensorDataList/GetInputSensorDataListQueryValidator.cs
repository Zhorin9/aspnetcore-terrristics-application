using Application.InputSensorDatas.Queries.GetInputSensorDataList;
using FluentValidation;

namespace Application.InputSensors.Queries.GetInputSensorDataList
{
    public class GetInputSensorDataListQueryValidator : AbstractValidator<GetInputSensorDataListQuery>
    {
        public GetInputSensorDataListQueryValidator()
        {
            RuleFor(v => v.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
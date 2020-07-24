using FluentValidation;

namespace Application.InputSensorDatas.Queries.GetInputSensorDataList
{
    public class GetInputSensorDataListQueryValidator : AbstractValidator<GetInputSensorDataListQuery>
    {
        public GetInputSensorDataListQueryValidator()
        {
            RuleFor(v => v.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
using FluentValidation;

namespace Application.OutputSensorDatas.Queries.GetOutputSensorData
{
    public class GetOutputSensorDataQueryValidator : AbstractValidator<GetOutputSensorDataQuery>
    {
        public GetOutputSensorDataQueryValidator()
        {
            RuleFor(x => x.SensorBlockId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
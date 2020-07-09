using MediatR;

namespace Application.OutputSensorDatas.Queries.GetOutputSensorData
{
    public class GetOutputSensorDataQuery : IRequest<OutputSensorDataAm>
    {
        public int SensorBlockId { get; set; }
    }
}
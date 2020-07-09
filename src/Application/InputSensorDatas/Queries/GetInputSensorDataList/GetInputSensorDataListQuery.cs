using MediatR;

namespace Application.InputSensors.Queries.GetInputSensorDataList
{
    public class GetInputSensorDataListQuery : IRequest<InputSensorDataListAm>
    {
        public int SensorBlockId { get; set; }
    }
}
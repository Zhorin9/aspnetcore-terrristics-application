using MediatR;

namespace Application.InputSensorDatas.Queries.GetInputSensorDataList
{
    public class GetInputSensorDataListQuery : IRequest<InputSensorDataListAm>
    {
        public int SensorBlockId { get; set; }
    }
}
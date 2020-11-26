using MediatR;

namespace Application.Sensors.Queries.GetSensorBlockList
{
    public class GetSensorBlockListQuery : IRequest<SensorBlockListAm>
    {
        public int WindowId { get; set; }
    }
}
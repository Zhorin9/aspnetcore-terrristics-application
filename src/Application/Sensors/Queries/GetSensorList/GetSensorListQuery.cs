using MediatR;

namespace Application.Sensors.Queries.GetSensorList
{
    public class GetSensorListQuery : IRequest<SensorListAm>
    {
        public int WindowId { get; set; }
    }
}
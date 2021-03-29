using MediatR;

namespace Application.Sensors.Queries.GetSensorDetail
{
    public class GetSensorDetailQuery : IRequest<SensorDetailAm>
    {
        public int Id { get; set; }
    }
}
using MediatR;

namespace Application.ControlSensors.Queries.GetControlSensor
{
    public class GetControlSensorQuery : IRequest<ControlSensorAm>
    {
        public int SensorBlockId { get; set; }
    }
}
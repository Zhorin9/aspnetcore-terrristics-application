using Application.Common.Mappings;
using AutoMapper;

namespace Application.ControlSensors.Queries.GetControlSensor
{
    public class ControlSensorAm : IMapFrom<Domain.Entities.ControlSensor>
    {
        public bool State { get; set; }

        public string Value { get; set; }
        
        public int SensorBlockId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ControlSensor, ControlSensorAm>()
                ;
        }
    }
}
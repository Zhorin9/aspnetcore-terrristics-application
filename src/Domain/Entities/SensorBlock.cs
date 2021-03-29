using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class SensorBlock : BaseEntity
    {
        public SensorBlock()
        {
            ReadSensors = new HashSet<ReadSensor>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public SensorTypeEnum Type { get; set; }
        public int SensorKindId { get; set; }
        public SensorKind SensorKind { get; set; }
        public string UserId { get; set; }
        public int ParentWindowId { get; set; }
        
        public int? ControlSensorId { get; set; }
        
        public TerraristicWindow ParentWindow { get; set; }
        public ICollection<ReadSensor> ReadSensors { get; }
        
        public ControlSensor ControlSensor { get; set; }
    }
}
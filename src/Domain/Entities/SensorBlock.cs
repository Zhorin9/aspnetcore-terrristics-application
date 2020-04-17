using System.Collections.Generic;

namespace Domain.Entities
{
    public class SensorBlock : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int SensorKindId { get; set; }
        public SensorKind SensorKind { get; set; }
        public string UserId { get; set; }
        public int ParentWindowId { get; set; }
        public TerraristicWindow ParentWindow { get; set; }
        public ICollection<InputSensorData> Inputs { get; set; }
        public ICollection<OutputSensorData> Outputs { get; set; }
    }
}
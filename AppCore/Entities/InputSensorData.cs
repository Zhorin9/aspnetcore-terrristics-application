using System;

namespace AppCore.Entities
{
    public class InputSensorData : BaseEntity
    { 
        public decimal Value { get; set; }
        public DateTime CreationDate { get; set; }
        public int SensorBlockId { get; set; }
        public SensorBlock SensorBlock { get; set; }
    }
}

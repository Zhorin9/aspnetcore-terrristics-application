using System;

namespace Domain.Entities
{
    public class ReadSensor : BaseEntity
    {
        public decimal Value { get; set; }
        public DateTime CreationDate { get; set; }
        public int SensorBlockId { get; set; }
        public SensorBlock SensorBlock { get; set; }
    }
}

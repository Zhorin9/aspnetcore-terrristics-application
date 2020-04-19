namespace Domain.Entities
{
    public class OutputSensorData : BaseEntity
    {
        public bool State { get; set; }
        
        public string Value { get; set; }
        public int SensorBlockId { get; set; }
        public SensorBlock SensorBlock { get; set; }
    }
}

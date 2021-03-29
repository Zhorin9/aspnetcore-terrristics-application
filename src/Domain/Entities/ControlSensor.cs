namespace Domain.Entities
{
    public class ControlSensor : BaseEntity
    {
        public bool State { get; set; }
        
        public string Value { get; set; }
        public int SensorBlockId { get; set; }
        public SensorBlock SensorBlock { get; set; }
    }
}

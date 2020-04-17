using Domain.Enums;

namespace Domain.Entities
{
    public class SensorKind : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public SensorTypeEnum Type { get; set; }
        public OutputTypeEnum OutputType { get; set; }
    }
}
namespace AppCore.Entities
{
    public class SensorKind : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Type { get; set; }
    }
}
namespace Web.Data.Entities
{
    public class Sensor : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte ColumnNumber { get; set; }
        public byte RowNumber { get; set; }

        public ApplicationUser User { get; set; }
        public SensorKind SensorKind { get; set; }
        public TerraristicWindow ParrentWindow { get; set; }
    }
}
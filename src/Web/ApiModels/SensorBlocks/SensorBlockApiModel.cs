namespace Web.ApiModels.SensorBlocks
{
    public class SensorBlockApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int WindowId { get; set; }

        public SensorKindApiModel SensorKind { get; set; }
    }
}
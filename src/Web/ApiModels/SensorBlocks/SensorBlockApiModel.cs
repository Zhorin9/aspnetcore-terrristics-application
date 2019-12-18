namespace Web.ApiModels.SensorBlocks
{
    public class SensorBlockApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public byte PositionId { get; set; }

        public SensorKindApiModel Type { get; set; }
    }
}
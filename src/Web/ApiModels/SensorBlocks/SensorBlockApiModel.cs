namespace Web.ApiModels.SensorBlocks
{
    public class SensorBlockApiModel
    {
        public int Id { get; set; }

        public byte PositionId { get; set; }

        public SensorKindApiModel Type { get; set; }
    }
}
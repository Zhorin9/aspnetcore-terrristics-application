using AppCore.Enums;

namespace Web.ViewModels.Api
{
    public class SensorKindViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SensorTypeEnum Type { get; set; }
    }
}
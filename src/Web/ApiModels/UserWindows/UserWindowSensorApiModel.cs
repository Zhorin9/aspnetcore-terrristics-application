using AppCore.Enums;

namespace Web.ApiModels.UserWindows
{
    public class UserWindowSensorApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SensorTypeEnum Type { get; set; }
    }
}
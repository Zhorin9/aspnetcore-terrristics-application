using AppCore.Enums;

namespace Web.ViewModels.UserWindow
{
    public class UserWindowSensorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SensorTypeEnum Type { get; set; }
    }
}
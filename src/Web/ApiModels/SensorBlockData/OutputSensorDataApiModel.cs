using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.SensorBlockData
{
    public class OutputSensorDataApiModel
    {
        [Required]
        public int SensorBlockId { get; set; }
        
        [Required]
        public bool State { get; set; }
        
        public string Value { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.SensorBlockData
{
    public class InputSensorBlockDataApiModel
    {
        [Required]
        public Guid WindowApiKey { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public int SensorBlockId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
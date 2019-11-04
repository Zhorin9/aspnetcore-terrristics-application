using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.UserWindows
{
    public class UserWindowApiModel
    {
        [Required]
        [Range(3, 30)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public List<UserWindowSensorApiModel> InputSensors { get; set; }
        public List<UserWindowSensorApiModel> OutputSensors { get; set; }
    }
}
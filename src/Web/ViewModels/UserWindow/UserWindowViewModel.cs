using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.UserWindow
{
    public class UserWindowViewModel
    {
        [Required]
        [Range(3, 30)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public List<UserWindowSensorViewModel> InputSensors { get; set; }
        public List<UserWindowSensorViewModel> OutputSensors { get; set; }
    }
}
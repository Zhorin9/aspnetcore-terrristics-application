using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.TerraristicsWindows
{
    public class TerraristicsWindowApiModel
    {
        [Required] [Range(3, 30)]
        public string Name { get; set; }

        [MaxLength(200)] 
        public string Description { get; set; }
    }
}
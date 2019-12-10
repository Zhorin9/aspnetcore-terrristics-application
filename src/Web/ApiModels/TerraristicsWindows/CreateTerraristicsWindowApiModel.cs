using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.TerraristicsWindows
{
    public class CreateTerraristicsWindowApiModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(200)] 
        public string Description { get; set; }
    }
}
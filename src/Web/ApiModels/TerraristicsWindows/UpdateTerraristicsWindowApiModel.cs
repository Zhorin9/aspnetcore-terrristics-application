using System.ComponentModel.DataAnnotations;

namespace Web.ApiModels.TerraristicsWindows
{
    public class UpdateTerraristicsWindowApiModel : CreateTerraristicsWindowApiModel
    {
        [Required]
        public int Id { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace AppCore.Enums
{
    public enum OutputTypeEnum
    {
        [Display(Name = "Cyfrowe")]
        Digital = 1,
        
        [Display(Name = "Analog")]
        Analog = 2,
    }
}
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum OutputTypeEnum
    {
        [Display(Name = "Cyfrowe")]
        Digital = 1,
        
        [Display(Name = "Analog")]
        Analog = 2,
    }
}
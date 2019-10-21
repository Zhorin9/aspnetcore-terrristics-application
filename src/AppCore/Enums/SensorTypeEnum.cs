﻿using System.ComponentModel.DataAnnotations;

namespace AppCore.Enums
{
    public enum SensorTypeEnum
    {
        [Display(Name = "Wejście")]
        Input = 1,

        [Display(Name = "Wyjście")]
        Output = 2,
    }
}
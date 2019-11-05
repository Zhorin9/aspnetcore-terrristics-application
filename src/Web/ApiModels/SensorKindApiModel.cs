﻿using AppCore.Enums;

namespace Web.ApiModels
{
    public class SensorKindApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public SensorTypeEnum Type { get; set; }
    }
}
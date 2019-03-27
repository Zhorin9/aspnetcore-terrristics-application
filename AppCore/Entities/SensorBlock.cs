﻿using System.Collections.Generic;

namespace AppCore.Entities
{
    public class SensorBlock : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte PositionId { get; set; }
        public int SensorKindId { get; set; }
        public SensorKind SensorKind { get; set; }
        public string UserId { get; set; }
        public int ParrentWindowId { get; set; }
        public TerraristicWindow ParrentWindow { get; set; }
        public IEnumerable<InputSensorData> Inputs { get; set; }
        public IEnumerable<OutputSensorData> Outputs { get; set; }
    }
}
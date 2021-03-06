﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TerraristicWindow : BaseEntity
    {
        public TerraristicWindow()
        {
            SensorBlocks = new HashSet<SensorBlock>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ApiKey { get; set; }
        public string UserId { get; set; }
        public bool IsPublic { get; set; }
        public IEnumerable<SensorBlock> SensorBlocks { get; }
    }
}
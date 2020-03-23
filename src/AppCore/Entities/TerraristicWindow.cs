using System;
using System.Collections.Generic;

namespace AppCore.Entities
{
    public class TerraristicWindow : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid ApiKey { get; set; }
        public string UserId { get; set; }
        public bool IsPublic { get; set; }
        public IEnumerable<SensorBlock> SensorBlocks { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Web.Identity;

namespace Web.Data.Entities
{
    public class TerraristicWindow : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid ApiKey { get; set; }
        public string UserId { get; set; }
        public IEnumerable<SensorBlock> SensorBlocks { get; set; }
    }
}

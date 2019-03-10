using System;
using System.Collections.Generic;

namespace Web.Data.Entities
{
    public class TerraristicWindow : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid ApiKey { get; set; }

        public ApplicationUser User { get; set; }
        public IEnumerable<Sensor> Sensors { get; set; }
    }
}

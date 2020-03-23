using System;

namespace Web.ApiModels.TerraristicsWindows
{
    public class TerraristicsWindowApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        
        public DateTime ModificationDate { get; set; }

        public string ApiKey { get; set; }

        public bool IsPublic { get; set; }
    }
}
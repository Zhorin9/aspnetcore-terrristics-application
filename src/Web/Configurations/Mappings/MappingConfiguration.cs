using AutoMapper;
using Web.Configurations.Mappings.Profiles;

namespace Web.Configurations.Mappings
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TerraristicsWindowMappingProfile());
                mc.AddProfile(new SensorBlockMappingProfile());
                mc.AddProfile(new SensorKindMappingProfile());
            });
        }
    }
}
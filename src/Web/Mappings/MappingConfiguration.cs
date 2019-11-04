using AutoMapper;
using Web.Mappings.Profiles;

namespace Web.Mappings
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToApiModelProfile());
            });
        }
    }
}
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Web.Configurations.Mappings;

namespace Web.Configurations
{
    public static class AutoMapperConfiguration
    {
        internal static void RegisterAutoMapper(IServiceCollection services)
        {
            IMapper mapper = MappingConfiguration.GetMapperConfiguration().CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
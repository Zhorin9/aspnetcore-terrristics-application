using AppCore.Entities;
using AutoMapper;
using Web.ApiModels.TerraristicsWindows;

namespace Web.Configurations.Mappings.Profiles
{
    public class TerraristicsWindowMappingProfile: Profile
    {
        public TerraristicsWindowMappingProfile()
        {
            CreateMap<TerraristicWindow, TerraristicsWindowApiModel>()
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreationDate.Date));
        }
    }
}
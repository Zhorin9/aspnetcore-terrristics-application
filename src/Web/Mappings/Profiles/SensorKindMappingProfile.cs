using AppCore.Entities;
using AutoMapper;
using Web.ApiModels;

namespace Web.Mappings.Profiles
{
    public class SensorKindMappingProfile : Profile
    {
        public SensorKindMappingProfile()
        {
            CreateMap<SensorKind, SensorKindApiModel>()
                .ForMember(d => d.SensorKindId, o => o.MapFrom(s => s.Id));
        }
    }
}
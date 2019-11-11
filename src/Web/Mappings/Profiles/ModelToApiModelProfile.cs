using AppCore.Entities;
using AutoMapper;
using Web.ApiModels;

namespace Web.Mappings.Profiles
{
    public class ModelToApiModelProfile : Profile
    {
        public ModelToApiModelProfile()
        {
            CreateMap<SensorKind, SensorKindApiModel>()
                .ForMember(d => d.SensorKindId, o => o.MapFrom(s => s.Id));
        }
    }
}
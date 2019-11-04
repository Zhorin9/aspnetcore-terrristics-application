using AppCore.Entities;
using AutoMapper;
using Web.ApiModels;

namespace Web.Mappings.Profiles
{
    public class ModelToApiModelProfile : Profile
    {
        public ModelToApiModelProfile()
        {
            CreateMap<SensorKind, SensorKindApiModel>();
        }
    }
}
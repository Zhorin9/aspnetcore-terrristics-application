using AppCore.Entities;
using AutoMapper;
using Web.ViewModels.Api;

namespace Web.Mappings.Profiles
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<SensorKind, SensorKindViewModel>();
        }
    }
}
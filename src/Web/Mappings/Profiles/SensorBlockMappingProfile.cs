using AppCore.Entities;
using AutoMapper;
using Web.ApiModels.SensorBlocks;

namespace Web.Mappings.Profiles
{
    public class SensorBlockMappingProfile : Profile
    {
        public SensorBlockMappingProfile()
        {
            CreateMap<SensorBlock, SensorBlockApiModel>()
                .ForMember(d => d.WindowId, o => o.MapFrom(s => s.ParentWindowId));

            CreateMap<InputSensorData, InputSensorBlockDataApiModel>();
        }
    }
}
using Domain.Entities;
using AutoMapper;
using Web.ApiModels.SensorBlockData;

namespace Web.Configurations.Mappings.Profiles
{
    public class SensorBlockMappingProfile : Profile
    {
        public SensorBlockMappingProfile()
        {
            CreateMap<InputSensorData, InputSensorBlockDataApiModel>();
        }
    }
}
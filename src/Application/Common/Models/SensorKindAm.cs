using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Models
{
    public class SensorKindAm : IMapFrom<SensorKind>
    {
        public int SensorKindId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public OutputTypeEnum OutputType { get; set; }
        public SensorTypeEnum Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SensorKind, SensorKindAm>()
                .ForMember(d => d.SensorKindId, o => o.MapFrom(s => s.Id));
        }
    }
}
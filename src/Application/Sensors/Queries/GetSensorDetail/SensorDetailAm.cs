using System;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Sensors.Queries.GetSensorDetail
{
    public class SensorDetailAm : IMapFrom<SensorBlock>
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int WindowId { get; set; }

        public SensorKindAm SensorKind { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SensorBlock, SensorDetailAm>()
                .ForMember(d => d.WindowId, o => o.MapFrom(s => s.ParentWindowId))
                .ForMember(d => d.SensorKind, o => o.MapFrom(s => s.SensorKind))
                ;
        }
    }
}
using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Terrariums.Queries.GetTerrariumDetail
{
    public class TerrariumDetailAm : IMapFrom<TerraristicWindow>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public string ApiKey { get; set; }

        public bool IsPublic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TerraristicWindow, TerrariumDetailAm>()
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreationDate.Date));
        }
    }
}
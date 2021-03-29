using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Terrariums.Queries.GetTerrariumList
{
    public class TerrariumListDetailAm : IMapFrom<TerraristicWindow>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string ApiKey { get; set; }

        public bool IsPublic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TerraristicWindow, TerrariumListDetailAm>()
                ;
        }
    }
}
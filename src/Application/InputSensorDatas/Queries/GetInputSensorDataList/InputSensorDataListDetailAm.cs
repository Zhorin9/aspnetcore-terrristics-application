using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.InputSensors.Queries.GetInputSensorDataList
{
    public class InputSensorDataListDetailAm : IMapFrom<InputSensorData>
    {
        public decimal Value { get; set; }

        public DateTime CreationDate { get; set; }

        public int SensorBlockId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<InputSensorData, InputSensorDataListDetailAm>()
                ;
        }
    }
}
using Application.Common.Mappings;
using AutoMapper;

namespace Application.OutputSensorDatas.Queries.GetOutputSensorData
{
    public class OutputSensorDataAm : IMapFrom<Domain.Entities.OutputSensorData>
    {
        public bool State { get; set; }

        public string Value { get; set; }
        
        public int SensorBlockId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.OutputSensorData, OutputSensorDataAm>()
                ;
        }
    }
}
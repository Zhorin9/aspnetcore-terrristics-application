using MediatR;

namespace Application.SensorBlocks.Queries.GetSensorBlockDetail
{
    public class GetSensorBlockDetailQuery : IRequest<SensorBlockDetailAm>
    {
        public int Id { get; set; }
    }
}
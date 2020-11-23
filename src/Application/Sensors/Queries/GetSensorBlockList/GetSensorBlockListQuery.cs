using MediatR;

namespace Application.SensorBlocks.Queries.GetSensorBlockList
{
    public class GetSensorBlockListQuery : IRequest<SensorBlockListAm>
    {
        public int WindowId { get; set; }
    }
}
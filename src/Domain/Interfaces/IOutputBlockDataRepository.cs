using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOutputBlockDataRepository
    {
        Task<OutputSensorData> Get(int sensorBlockId);

        Task<OutputSensorData> CreateOrUpdate(OutputSensorData outputSensorData);
    }
}
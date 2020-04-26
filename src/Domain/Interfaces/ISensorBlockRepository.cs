using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISensorBlockRepository : IAsyncAppRepository<SensorBlock>
    {
        Task<int> UpdateBaseParameters(SensorBlock sensorBlockToUpdate, string userId);
        
        Task<int> CreateWithOutputData(SensorBlock sensorBlock);

        Task<List<SensorBlock>> GetAsync(int windowId, string userId);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISensorBlockRepository : IAsyncAppRepository<SensorBlock>
    {
        Task<List<SensorBlock>> GetAsync(int windowId, string userId);
    }
}
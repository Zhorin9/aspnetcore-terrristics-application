using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Entities;

namespace AppCore.Interfaces
{
    public interface ISensorBlockRepository : IAsyncAppRepository<SensorBlock>
    {
        Task<List<SensorBlock>> GetAsync(string userId);
    }
}
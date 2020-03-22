using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface ITerraristicWindowRepository : IAsyncAppRepository<TerraristicWindow>
    {
        Task<TerraristicWindow> GetAsync(int id, string userId);

        Task<List<TerraristicWindow>> GetAsync(string userId);

        /// <summary> Get windows list by specified user </summary>
        Task<List<TerraristicWindow>> GetByUserIdWithItemsAsync(string userId);

        Task<int> Update(TerraristicWindow model, string userId);
    }
}
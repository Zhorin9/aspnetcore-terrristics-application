using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface ITerraristicWindowRepository : IAsyncAppRepository<TerraristicWindow>
    {
        Task<TerraristicWindow> GetAsync(int id, string userId);

        Task<List<TerraristicWindow>> GetAsync(string userId);
        
        /// <summary> Get window with included items </summary>
        Task<TerraristicWindow> GetWithItemsAsync(int id);

        /// <summary> Get window with included items </summary>
        Task<TerraristicWindow> GetWithItemsAsync(int id, string userId);

        /// <summary> Get windows list by specified user </summary>
        Task<List<TerraristicWindow>> GetByUserIdWithItemsAsync(string userId);
    }
}
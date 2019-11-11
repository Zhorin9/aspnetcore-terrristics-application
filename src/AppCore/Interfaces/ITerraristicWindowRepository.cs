using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface ITerraristicWindowRepository : IAsyncAppRepository<TerraristicWindow>

    {
    /// <summary>
    /// Get window with included items for specified id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TerraristicWindow> GetByIdWithItemsAsync(int id);

    /// <summary>
    /// Get windows list by specified user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<TerraristicWindow>> GetByUserIdWithItemsAsync(string userId);
    }
}

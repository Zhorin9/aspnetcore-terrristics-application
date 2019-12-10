using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TerraristicWindowRepository : AppRepository<TerraristicWindow>, ITerraristicWindowRepository
    {
        private readonly IAppLogger<TerraristicWindowRepository> _logger;
        public TerraristicWindowRepository(AppDbContext context, IAppLogger<TerraristicWindowRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public Task<TerraristicWindow> GetAsync(int id, string userId)
        {
            return Context.TerraristicWindows
                .Where(p => p.Id == id && p.UserId == userId)
                .FirstAsync();
        }

        public Task<List<TerraristicWindow>> GetAsync(string userId)
        {
            return Context.TerraristicWindows
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<TerraristicWindow> GetWithItemsAsync(int id)
        {
            //TODO Add log information if null
            return await Context.TerraristicWindows
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Inputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Outputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.SensorKind)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<TerraristicWindow> GetWithItemsAsync(int id, string userId)
        {
            //TODO Add log information if null
            return await Context.TerraristicWindows
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Inputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Outputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.SensorKind)
                    .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        }

        public Task<List<TerraristicWindow>> GetByUserIdWithItemsAsync(string userId)
        {
            //TODO Add log information if null
            return Context.TerraristicWindows
                    .Where(p => p.UserId == userId)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Inputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Outputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.SensorKind)
                    .ToListAsync();
        }
    }
}

using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class TerraristicWindowRepository : AppRepository<TerraristicWindow>, ITerraristicWindowRepository
    {
        public TerraristicWindowRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<TerraristicWindow> GetByIdWithItemsAsync(int id)
        {
            return await _context.TerraristicWindows
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Inputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Outputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.SensorKind)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<TerraristicWindow>> GetByUserIdWithItemsAsync(string userId)
        {
            return _context.TerraristicWindows
                    .Where(p => p.UserId == userId)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Inputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Outputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.SensorKind)
                    .ToListAsync();
        }
    }
}

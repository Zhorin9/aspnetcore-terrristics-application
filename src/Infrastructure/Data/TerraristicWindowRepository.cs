using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TerraristicWindowRepository : AppRepository<TerraristicWindow>, ITerraristicWindowRepository
    {
        public TerraristicWindowRepository(AppDbContext context) : base(context)
        {
        }

        public Task<TerraristicWindow> GetByIdWithItemsAsync(int id)
        {
            return _context.TerraristicWindows
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Inputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.Outputs)
                    .Include(o => o.SensorBlocks).ThenInclude(p => p.SensorKind)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

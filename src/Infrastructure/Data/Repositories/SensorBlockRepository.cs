using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class SensorBlockRepository : AppRepository<SensorBlock>, ISensorBlockRepository
    {
        private readonly IAppLogger<TerraristicWindowRepository> _logger;

        public SensorBlockRepository(AppDbContext context, IAppLogger<TerraristicWindowRepository> logger) :
            base(context)
        {
            _logger = logger;
        }


        public Task<List<SensorBlock>> GetAsync(int windowId, string userId)
        {
            return Context.SensorBlocks.AsNoTracking()
                .Include(sb => sb.SensorKind)
                .Where(sb => sb.ParentWindowId == windowId && sb.UserId == userId)
                .ToListAsync();
        }
    }
}
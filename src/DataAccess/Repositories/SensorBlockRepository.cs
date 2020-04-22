using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SensorBlockRepository : AppRepository<SensorBlock>, ISensorBlockRepository
    {
        private readonly IAppLogger<TerraristicWindowRepository> _logger;

        public SensorBlockRepository(AppDbContext context, IAppLogger<TerraristicWindowRepository> logger) :
            base(context)
        {
            _logger = logger;
        }

        public async Task<int> CreateWithOutputData(SensorBlock sensorBlock)
        {
            await Context.SensorBlocks.AddAsync(sensorBlock);
            int result = await Context.SaveChangesAsync();

            return result;
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
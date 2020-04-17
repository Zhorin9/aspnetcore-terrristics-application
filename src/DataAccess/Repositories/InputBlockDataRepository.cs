using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class InputBlockDataRepository : AppRepository<InputSensorData>, IInputBlockDataRepository
    {
        private readonly IAppLogger<TerraristicWindowRepository> _logger;

        public InputBlockDataRepository(AppDbContext context, IAppLogger<TerraristicWindowRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<int> Add(Guid windowApiKey, int sensorBlockId, InputSensorData inputSensorData)
        {
            TerraristicWindow terraristicWindow = await Context.TerraristicWindows
                .Include(i => i.SensorBlocks)
                .FirstOrDefaultAsync(t => t.ApiKey == windowApiKey); 
            SensorBlock sensorBlock = terraristicWindow?.SensorBlocks.FirstOrDefault(s => s.Id == sensorBlockId);
            
            if (sensorBlock == null)
            {
                return -1;
            }
            
            return await AddAsync(inputSensorData);
        } 

        public Task<List<InputSensorData>> GetData(int sensorBlockId)
        {
            return Context.InputSensorData.Where(d => d.SensorBlockId == sensorBlockId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
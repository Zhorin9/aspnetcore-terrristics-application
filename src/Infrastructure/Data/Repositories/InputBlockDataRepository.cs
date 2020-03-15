using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class InputBlockDataRepository : AppRepository<InputSensorData>, IInputBlockDataRepository
    {
        private readonly IAppLogger<TerraristicWindowRepository> _logger;

        public InputBlockDataRepository(AppDbContext context, IAppLogger<TerraristicWindowRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public Task<List<InputSensorData>> GetData(int sensorBlockId)
        {
            return Context.InputSensorData.Where(d => d.SensorBlockId == sensorBlockId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
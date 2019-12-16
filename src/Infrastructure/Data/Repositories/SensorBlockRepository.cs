using AppCore.Entities;
using AppCore.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class SensorBlockRepository : AppRepository<SensorBlock>, ISensorBlockRepository
    {
        private readonly IAppLogger<TerraristicWindowRepository> _logger;
        
        public SensorBlockRepository(AppDbContext context, IAppLogger<TerraristicWindowRepository> logger) : base(context)
        {
            _logger = logger;
        }
        
        
    }
}
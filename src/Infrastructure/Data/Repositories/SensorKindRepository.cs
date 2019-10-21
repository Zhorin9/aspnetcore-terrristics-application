using AppCore.Entities;
using AppCore.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class SensorKindRepository : AppRepository<SensorKind>, ISensorKindRepository
    { 
        public SensorKindRepository(AppDbContext context) : base(context)
        {

        }
    }
}
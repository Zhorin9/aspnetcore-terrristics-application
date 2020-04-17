using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class SensorKindRepository : AppRepository<SensorKind>, ISensorKindRepository
    { 
        public SensorKindRepository(AppDbContext context) : base(context)
        {

        }
    }
}
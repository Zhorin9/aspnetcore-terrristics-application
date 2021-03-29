using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<SensorBlock> SensorBlocks { get; set; }
        public DbSet<SensorKind> SensorKinds { get; set; }
        public DbSet<ReadSensor> ReadSensors { get; set; }

        public DbSet<ControlSensor> ControlSensors { get; set; }
        public DbSet<TerraristicWindow> TerraristicWindows { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<SensorBlock> SensorBlocks { get; set; }
        public DbSet<SensorKind> SensorKinds { get; set; }
        public DbSet<ReadSensor> ReadSensors { get; set; }

        public DbSet<ControlSensor> ControlSensors { get; set; }
        public DbSet<TerraristicWindow> TerraristicWindows { get; set; }

        public override int SaveChanges()
        {
            StampWithDatesAndUsers();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            StampWithDatesAndUsers();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void StampWithDatesAndUsers()
        {
            DateTime now = DateTime.UtcNow;
            string currentUser = _currentUserService?.UserId ?? "SYSTEM";

            foreach (EntityEntry entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.Entity is BaseEntity entity)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.CreatedBy = currentUser;
                            entity.ModifiedDate = now;
                            entity.ModifiedBy = currentUser;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedDate = now;
                            entity.ModifiedBy = currentUser;
                            break;
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
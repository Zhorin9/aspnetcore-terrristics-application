using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SensorBlockConfiguration : IEntityTypeConfiguration<SensorBlock>
    {
        public void Configure(EntityTypeBuilder<SensorBlock> builder)
        {
            builder.ToTable("SensorBlock");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.HasMany(s => s.ReadSensors)
                .WithOne(s => s.SensorBlock);
            builder.HasOne(s => s.ControlSensor)
                .WithOne(s => s.SensorBlock)
                .HasForeignKey<SensorBlock>(s => s.ControlSensorId);

            builder.HasOne(s => s.ParentWindow)
                .WithMany(s => s.SensorBlocks)
                .HasForeignKey(s => s.ParentWindowId);
        }
    }
}
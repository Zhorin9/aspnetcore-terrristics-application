using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Configurations
{
    public class ControlSensorConfiguration : IEntityTypeConfiguration<ControlSensor>
    {
        public void Configure(EntityTypeBuilder<ControlSensor> builder)
        {
            builder.ToTable("ControlSensor");

            builder.Property(e => e.State)
                .HasConversion(new BoolToZeroOneConverter<int>())
                .IsRequired();

            builder.HasOne(e => e.SensorBlock)
                .WithOne(e => e.ControlSensor)
                .HasForeignKey<ControlSensor>(e => e.SensorBlockId);
        }
    }
}
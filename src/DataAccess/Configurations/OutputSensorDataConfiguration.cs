using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Configurations
{
    public class OutputSensorDataConfiguration : IEntityTypeConfiguration<OutputSensorData>
    {
        public void Configure(EntityTypeBuilder<OutputSensorData> builder)
        {
            builder.ToTable("OutputSensorData");

            builder.Property(e => e.State)
                .HasConversion(new BoolToZeroOneConverter<int>())
                .IsRequired();

            builder.HasOne(e => e.SensorBlock)
                .WithOne(e => e.OutputData)
                .HasForeignKey<OutputSensorData>(e => e.SensorBlockId);
        }
    }
}
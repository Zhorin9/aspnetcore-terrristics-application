using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class InputSensorDataConfiguration : IEntityTypeConfiguration<InputSensorData>
    {
        public void Configure(EntityTypeBuilder<InputSensorData> builder)
        {
            builder.ToTable("InputSensorData");
            
            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);

            //Decimal(5,2) is precision to 999.s
            builder.Property(e => e.Value)
                .HasColumnType("decimal(5,2)");

            builder.HasOne(e => e.SensorBlock)
                .WithMany(e => e.Inputs)
                .HasForeignKey(e => e.SensorBlockId);
        }
    }
}
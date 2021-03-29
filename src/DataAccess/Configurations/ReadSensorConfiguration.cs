using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ReadSensorConfiguration : IEntityTypeConfiguration<ReadSensor>
    {
        public void Configure(EntityTypeBuilder<ReadSensor> builder)
        {
            builder.ToTable("ReadSensor");
            
            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);

            //Decimal(5,2) is precision to 999.s
            builder.Property(e => e.Value)
                .HasColumnType("decimal(5,2)");

            builder.HasOne(e => e.SensorBlock)
                .WithMany(e => e.ReadSensors)
                .HasForeignKey(e => e.SensorBlockId);
        }
    }
}
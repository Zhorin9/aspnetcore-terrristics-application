using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Configurations
{
    public class TerraristicWindowConfiguration : IEntityTypeConfiguration<TerraristicWindow>
    {
        public void Configure(EntityTypeBuilder<TerraristicWindow> builder)
        {
            builder.ToTable("TerraristicWindow");
            
            builder.Property(tw => tw.ApiKey)
                .HasConversion(new GuidToStringConverter())
                .HasDefaultValue(Guid.NewGuid());
            builder.Property(tw => tw.CreationDate)
                .HasColumnType("date")
                .HasDefaultValue(DateTime.Now);
            builder.Property(tw => tw.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(tw => tw.ModificationDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);
            builder.Property(tw => tw.IsPublic)
                .HasConversion(new BoolToZeroOneConverter<int>());

            builder.HasMany(tw => tw.SensorBlocks)
                .WithOne(tw => tw.ParentWindow);
        }
    }
}
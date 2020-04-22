using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SensorBlock> SensorBlocks { get; set; }
        public DbSet<SensorKind> SensorKinds { get; set; }
        public DbSet<InputSensorData> InputSensorData { get; set; }

        public DbSet<OutputSensorData> OutputSensorData { get; set; }
        public DbSet<TerraristicWindow> TerraristicWindows { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SensorKind>(ConfigureSensorKind);
            builder.Entity<TerraristicWindow>(ConfigureTerraristicWindow);
            builder.Entity<SensorBlock>(ConfigureSensorBlock);
            builder.Entity<InputSensorData>(ConfigureInputSensorData);
            builder.Entity<OutputSensorData>(ConfigureOutputSensorData);
        }

        private void ConfigureSensorKind(EntityTypeBuilder<SensorKind> builder)
        {
            builder.ToTable("SensorKind");

            builder.HasKey(sk => sk.Id);
            builder.Property(sk => sk.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(sk => sk.Description)
                .HasMaxLength(500);
            //Type 0 - output | 1 - input
            builder.Property(sk => sk.Type)
                .IsRequired();
        }

        private void ConfigureInputSensorData(EntityTypeBuilder<InputSensorData> builder)
        {
            builder.HasKey(isd => isd.Id);
            builder.Property(isd => isd.CreationDate)
                .HasColumnType("date")
                .HasDefaultValue(DateTime.Now);

            //Decimal(5,2) is precision to 999.99
            builder.Property(isd => isd.Value)
                .HasColumnType("decimal(5,2)");

            builder.HasOne(isd => isd.SensorBlock)
                .WithMany(isd => isd.Inputs)
                .HasForeignKey(isd => isd.SensorBlockId);
        }

        private void ConfigureOutputSensorData(EntityTypeBuilder<OutputSensorData> builder)
        {
            builder.ToTable("OutputSensorData");

            builder.HasKey(osd => osd.Id);
            builder.Property(osd => osd.State)
                .HasConversion(new BoolToZeroOneConverter<int>())
                .IsRequired();

            builder.HasOne(osd => osd.SensorBlock)
                .WithOne(osd => osd.OutputData)
                .HasForeignKey<OutputSensorData>(osd => osd.SensorBlockId);
        }

        private void ConfigureSensorBlock(EntityTypeBuilder<SensorBlock> builder)
        {
            builder.ToTable("SensorBlock");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.HasMany(s => s.Inputs)
                .WithOne(s => s.SensorBlock);
            builder.HasOne(s => s.OutputData)
                .WithOne(s => s.SensorBlock)
                .HasForeignKey<SensorBlock>(s => s.OutputDataId);

            builder.HasOne(s => s.ParentWindow)
                .WithMany(s => s.SensorBlocks)
                .HasForeignKey(s => s.ParentWindowId);
        }

        private void ConfigureTerraristicWindow(EntityTypeBuilder<TerraristicWindow> builder)
        {
            builder.ToTable("TerraristicWindow");

            builder.HasKey(p => p.Id);

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
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SensorKindConfiguration : IEntityTypeConfiguration<SensorKind>
    {
        public void Configure(EntityTypeBuilder<SensorKind> builder)
        {
            builder.ToTable("SensorKind");

            builder.Property(sk => sk.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(sk => sk.Description)
                .HasMaxLength(500);
            //Type 0 - output | 1 - input
            builder.Property(sk => sk.Type)
                .IsRequired();
        }
    }
}
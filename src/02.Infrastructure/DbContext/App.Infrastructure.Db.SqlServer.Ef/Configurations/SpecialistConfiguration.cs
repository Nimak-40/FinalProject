using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class CityConfiguration
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.Property(s => s.Specialty)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Rating)
                   .HasDefaultValue(0)
                   .HasPrecision(2, 1);

            builder.HasMany(s => s.OrderRequests)
                   .WithOne(o => o.Specialist)
                   .HasForeignKey(o => o.SpecialistId)
                   .OnDelete(DeleteBehavior.SetNull);

        }
    }
}

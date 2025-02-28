using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
{
    public void Configure(EntityTypeBuilder<Specialist> builder)
    {
        builder.HasKey(s => s.UserId);
        builder.HasOne(s => s.User)
               .WithOne(u => u.Specialist)
               .HasForeignKey<Specialist>(s => s.UserId);

        builder.HasData(new Specialist { UserId = 2, Specialty = "Plumbing", Rating = 4.5, IsAvailable = true });
    }
}



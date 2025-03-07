using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.src.Infrastructure.Configurations
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.HasKey(s => s.UserId);
            builder.HasOne(s => s.User)
                   .WithOne(u => u.Specialist)
                   .HasForeignKey<Specialist>(s => s.UserId);

            builder.HasData(new Specialist { UserId = 2, Rating = 4.5, IsAvailable = true });
        }
    }
}



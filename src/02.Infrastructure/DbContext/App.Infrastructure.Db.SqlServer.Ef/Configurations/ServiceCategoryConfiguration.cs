using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class CityConfiguration
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(sc => sc.Services)
                   .WithOne(s => s.ServiceCategory)
                   .HasForeignKey(s => s.ServiceCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasData(
                new ServiceCategory { Id = 1, Name = "نظافت" },
                new ServiceCategory { Id = 2, Name = "تعمیرات" },
                new ServiceCategory { Id = 3, Name = "خدمات زیبایی" },
                new ServiceCategory { Id = 4, Name = "آموزش" },
                new ServiceCategory { Id = 5, Name = "حمل و نقل" }
            );
        }
    }


}

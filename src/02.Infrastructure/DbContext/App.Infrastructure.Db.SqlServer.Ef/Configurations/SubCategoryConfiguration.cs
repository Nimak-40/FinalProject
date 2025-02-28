using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Achare.src.Infrastructure.Persistence.Configurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(sc => sc.IsActive)
                   .IsRequired();
                   

            builder.HasMany(sc => sc.Services)
                   .WithOne(s => s.SubCategory)
                   .HasForeignKey(s => s.SubCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

         
        }
    }
}

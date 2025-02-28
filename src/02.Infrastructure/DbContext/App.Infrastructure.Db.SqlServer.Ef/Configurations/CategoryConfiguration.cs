using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Achare.src.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.ImagePath)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(c => c.IsActive)
                   .IsRequired();

            builder.HasMany(c => c.SubCategories)
                   .WithOne(s => s.Category)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade); 

            
        }
    }
}

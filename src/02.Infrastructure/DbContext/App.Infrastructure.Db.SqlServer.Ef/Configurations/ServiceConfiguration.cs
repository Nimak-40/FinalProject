using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.ImagePath)
                .HasMaxLength(500);

            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(s => s.SubCategory)
                .WithMany(sc => sc.Services)
                .HasForeignKey(s => s.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Orders)
                .WithOne(o => o.Service)
                .HasForeignKey(o => o.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Specialists)
                .WithMany(sp => sp.Services);
        }
    }
    




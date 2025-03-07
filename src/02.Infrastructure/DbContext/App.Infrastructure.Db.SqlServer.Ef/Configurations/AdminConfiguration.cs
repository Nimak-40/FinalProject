using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace App.src.Infrastructure.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.User)
                   .WithOne(u => u.Admin)
                   .HasForeignKey<Admin>(a => a.UserId);

            builder.HasData(new Admin { Id = 1, UserId = 1 });
        }
    }
}


using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace App.src.Infrastructure.Configurations
{ 
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.User)
               .WithOne(u => u.Customer)
               .HasForeignKey<Customer>(c => c.UserId);

        builder.HasData(
            new Customer { Id = 1, UserId = 3, CityId = 1 },
            new Customer { Id = 2, UserId = 4, CityId = 1 }
        );
    }
}
}


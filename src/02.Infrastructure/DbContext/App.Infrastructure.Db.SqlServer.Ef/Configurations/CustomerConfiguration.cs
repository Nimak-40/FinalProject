using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class CityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.PreferredAddress)
                   .HasMaxLength(200);

            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
            new Customer { Id = 1, Username = "customer1", Email = "cust1@example.com", PasswordHash = "123456", PreferredAddress = "Tehran, St. 1" },
            new Customer { Id = 2, Username = "customer2", Email = "cust2@example.com", PasswordHash = "123456", PreferredAddress = "Mashhad, St. 2" },
            new Customer { Id = 3, Username = "customer3", Email = "cust3@example.com", PasswordHash = "123456", PreferredAddress = "Isfahan, St. 3" },
            new Customer { Id = 4, Username = "customer4", Email = "cust4@example.com", PasswordHash = "123456", PreferredAddress = "Shiraz, St. 4" },
            new Customer { Id = 5, Username = "customer5", Email = "cust5@example.com", PasswordHash = "123456", PreferredAddress = "Tabriz, St. 5" },
            new Customer { Id = 6, Username = "customer6", Email = "cust6@example.com", PasswordHash = "123456", PreferredAddress = "Karaj, St. 6" },
            new Customer { Id = 7, Username = "customer7", Email = "cust7@example.com", PasswordHash = "123456", PreferredAddress = "Qom, St. 7" },
            new Customer { Id = 8, Username = "customer8", Email = "cust8@example.com", PasswordHash = "123456", PreferredAddress = "Ahvaz, St. 8" },
            new Customer { Id = 9, Username = "customer9", Email = "cust9@example.com", PasswordHash = "123456", PreferredAddress = "Kermanshah, St. 9" },
            new Customer { Id = 10, Username = "customer10", Email = "cust10@example.com", PasswordHash = "123456", PreferredAddress = "Urmia, St. 10" }
        );
        }
    }
}

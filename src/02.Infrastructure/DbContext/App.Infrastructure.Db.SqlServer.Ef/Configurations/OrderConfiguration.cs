using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class CityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(o => o.Payments)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.OrderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(o => o.Reviews)
                   .WithOne(r => r.Order)
                   .HasForeignKey(r => r.OrderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(o => o.ChatMessages)
                   .WithOne(m => m.Order)
                   .HasForeignKey(m => m.OrderId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

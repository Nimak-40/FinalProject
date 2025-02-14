using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class CityConfiguration
{
    public class OrderRequestConfiguration : IEntityTypeConfiguration<OrderRequest>
    {
        public void Configure(EntityTypeBuilder<OrderRequest> builder)
        {
            builder.HasKey(or => or.Id);

            builder.HasOne(or => or.Order)
                   .WithMany(o => o.OrderRequests)
                   .HasForeignKey(or => or.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(or => or.Specialist)
                   .WithMany(s => s.OrderRequests)
                   .HasForeignKey(or => or.SpecialistId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(or => or.Status)
                   .HasConversion<string>();
        }
    }

}

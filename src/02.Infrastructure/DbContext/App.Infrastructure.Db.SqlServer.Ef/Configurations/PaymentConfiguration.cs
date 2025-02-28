using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(p => p.PaymentDate)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(p => p.Order)
               .WithMany(o => o.Payments)
               .HasForeignKey(p => p.OrderId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Method)
               .IsRequired();

        builder.Property(p => p.Status)
               .IsRequired();
    }
}

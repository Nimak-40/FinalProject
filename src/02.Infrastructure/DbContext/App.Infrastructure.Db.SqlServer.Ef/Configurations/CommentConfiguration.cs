using App.src.Domain.Core.Entities;
using App.src.Domain.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace App.src.Infrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Message)
                   .IsRequired()
                   .HasMaxLength(500);

            // ارتباط با مشتری (Cascade حذف شود یا NoAction تنظیم شود)
            builder.HasOne(m => m.Customer)
                   .WithMany(c => c.Comments)
                   .HasForeignKey(m => m.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ارتباط با سفارش (NoAction تنظیم شود)
            builder.HasOne(m => m.Order)
                   .WithMany(o => o.Comments)
                   .HasForeignKey(m => m.OrderId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
﻿using App.src.Domain.Core.Entities;
using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace App.src.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasMany(o => o.Payments)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.OrderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(o => o.Reviews)
                   .WithOne(r => r.Order)
                   .HasForeignKey(r => r.OrderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(o => o.Comments)
                   .WithOne(m => m.Order)
                   .HasForeignKey(m => m.OrderId)
                   .OnDelete(DeleteBehavior.NoAction); // از SetNull به NoAction تغییر داده شد
        }
    }
}

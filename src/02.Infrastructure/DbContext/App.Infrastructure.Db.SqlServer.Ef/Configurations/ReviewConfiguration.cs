﻿using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.src.Infrastructure.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {

            builder.HasKey(r => r.Id);


            builder.Property(r => r.Rating)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(r => r.Comment)
                .HasMaxLength(1000);

            builder.Property(r => r.ReviewDate)
                .HasDefaultValueSql("GETUTCDATE()");


            builder.HasOne(r => r.Order)
                .WithMany(o => o.Reviews)
                .HasForeignKey(r => r.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


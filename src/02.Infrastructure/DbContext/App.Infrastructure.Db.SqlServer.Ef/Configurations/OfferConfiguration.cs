using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(or => or.Id);

            builder.HasOne(or => or.Order)
                   .WithMany(o => o.OrderOffers)
                   .HasForeignKey(or => or.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(or => or.Specialist)
                   .WithMany(s => s.OffersRequests)
                   .HasForeignKey(or => or.SpecialistId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(or => or.Status)
                   .HasConversion<string>();
        }
    }



using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class CityConfiguration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Description)
                   .HasMaxLength(500);

            builder.Property(s => s.Price)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(s => s.ServiceCategory)
                   .WithMany(sc => sc.Services)
                   .HasForeignKey(s => s.ServiceCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seeding 10 Services
            builder.HasData(
                new Service { Id = 1, Name = "نظافت منزل", Description = "نظافت کامل منزل توسط نیروی متخصص", Price = 500000, ServiceCategoryId = 1 },
                new Service { Id = 2, Name = "شستشوی فرش", Description = "شستشوی انواع فرش و موکت", Price = 300000, ServiceCategoryId = 1 },
                new Service { Id = 3, Name = "تعمیر لوازم خانگی", Description = "تعمیر یخچال، ماشین لباسشویی و ...", Price = 700000, ServiceCategoryId = 2 },
                new Service { Id = 4, Name = "نقاشی ساختمان", Description = "نقاشی داخلی و خارجی ساختمان", Price = 1200000, ServiceCategoryId = 2 },
                new Service { Id = 5, Name = "اصلاح مو", Description = "خدمات اصلاح و آرایش مو", Price = 150000, ServiceCategoryId = 3 },
                new Service { Id = 6, Name = "میکاپ", Description = "میکاپ تخصصی عروس و مجالس", Price = 800000, ServiceCategoryId = 3 },
                new Service { Id = 7, Name = "کلاس زبان انگلیسی", Description = "آموزش زبان انگلیسی با بهترین اساتید", Price = 400000, ServiceCategoryId = 4 },
                new Service { Id = 8, Name = "کلاس موسیقی", Description = "آموزش انواع سازها", Price = 500000, ServiceCategoryId = 4 },
                new Service { Id = 9, Name = "باربری و اثاث‌کشی", Description = "خدمات حمل و نقل اثاثیه", Price = 2000000, ServiceCategoryId = 5 },
                new Service { Id = 10, Name = "حمل‌ونقل مسافران", Description = "جابجایی مسافران با خودروهای لوکس", Price = 1000000, ServiceCategoryId = 5 }
            );
        }
    }


}

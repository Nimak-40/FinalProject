using App.src.Domain.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.State)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(c => c.Users)
               .WithOne(u => u.City)
               .HasForeignKey(u => u.CityId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new City { Id = 1, Name = "Tehran", State = "Tehran" },
            new City { Id = 2, Name = "Mashhad", State = "Mashhad" },
            new City { Id = 3, Name = "Isfahan", State = "Isfahan" },
            new City { Id = 4, Name = "Shiraz", State = "Shiraz" },
            new City { Id = 5, Name = "Tabriz", State = "Tabriz" },
            new City { Id = 6, Name = "Karaj", State = "Karaj" },
            new City { Id = 7, Name = "Qom", State = "Qom" },
            new City { Id = 8, Name = "Ahvaz", State = "Ahvaz" },
            new City { Id = 9, Name = "Kermanshah", State = "Kermanshah" },
            new City { Id = 10, Name = "Urmia", State = "Urmia" }
        );
    }
}

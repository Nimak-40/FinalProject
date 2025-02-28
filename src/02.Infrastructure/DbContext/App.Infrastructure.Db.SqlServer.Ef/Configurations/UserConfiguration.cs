using App.src.Domain.Core.Entities.BaseEntities;
using App.src.Domain.Core.Entities.UserEntities;
using App.src.Domain.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace App.src.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration
    {
        public static void SeedUsers(ModelBuilder builder)
        {
            var passwordHasher = new PasswordHasher<User>();

            var users = new List<User>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Ahmadi",
                    Balance = 100000,
                    Status = UserStatusEnum.Accepted,
                    CityId = 1,
                    UserName = "Admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "Admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false
                },
                new()
                {
                    Id = 2,
                    FirstName = "Reza",
                    LastName = "Taheri",
                    Balance = 100000,
                    Status = UserStatusEnum.Accepted,
                    CityId = 1,
                    UserName = "Specialist@gmail.com",
                    NormalizedUserName = "SPECIALIST@GMAIL.COM",
                    Email = "Specialist@gmail.com",
                    NormalizedEmail = "SPECIALIST@GMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Specialist123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false
                },
                new()
                {
                    Id = 3,
                    FirstName = "Sara",
                    LastName = "Mohammadi",
                    Balance = 100000,
                    Status = UserStatusEnum.Accepted,
                    CityId = 1,
                    UserName = "Customer1@gmail.com",
                    NormalizedUserName = "CUSTOMER1@GMAIL.COM",
                    Email = "Customer1@gmail.com",
                    NormalizedEmail = "CUSTOMER1@GMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false
                },
                new()
                {
                    Id = 4,
                    FirstName = "Mina",
                    LastName = "Hosseini",
                    Balance = 100000,
                    Status = UserStatusEnum.Accepted,
                    CityId = 1,
                    UserName = "Customer2@gmail.com",
                    NormalizedUserName = "CUSTOMER2@GMAIL.COM",
                    Email = "Customer2@gmail.com",
                    NormalizedEmail = "CUSTOMER2@GMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false
                }
            };

            builder.Entity<User>().HasData(users);

            // Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Expert", NormalizedName = "EXPERT" },
                new IdentityRole<int>() { Id = 3, Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            // Seed Role To Users
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 3 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 4 }
            );

            // Seed Claims
            builder.Entity<IdentityUserClaim<int>>().HasData(
                new IdentityUserClaim<int>() { Id = 1, UserId = 1, ClaimType = ClaimTypes.Role, ClaimValue = "Admin" },
                new IdentityUserClaim<int>() { Id = 2, UserId = 1, ClaimType = ClaimTypes.Email, ClaimValue = "Admin@gmail.com" },
                new IdentityUserClaim<int>() { Id = 3, UserId = 2, ClaimType = ClaimTypes.Role, ClaimValue = "Expert" },
                new IdentityUserClaim<int>() { Id = 4, UserId = 2, ClaimType = ClaimTypes.Email, ClaimValue = "Specialist@gmail.com" },
                new IdentityUserClaim<int>() { Id = 5, UserId = 3, ClaimType = ClaimTypes.Role, ClaimValue = "Customer" },
                new IdentityUserClaim<int>() { Id = 6, UserId = 3, ClaimType = ClaimTypes.Email, ClaimValue = "Customer1@gmail.com" },
                new IdentityUserClaim<int>() { Id = 7, UserId = 4, ClaimType = ClaimTypes.Role, ClaimValue = "Customer" },
                new IdentityUserClaim<int>() { Id = 8, UserId = 4, ClaimType = ClaimTypes.Email, ClaimValue = "Customer2@gmail.com" }
            );
        }
    }
}

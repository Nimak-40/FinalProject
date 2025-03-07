using App.src.Domain.Core.Entities.BaseEntities;
using App.src.Domain.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.src.Domain.Core.Entities.UserEntities
{

    public class User : IdentityUser<int>
    {

        [MaxLength(60)]
        public string? FirstName { get; set; }
        [MaxLength(60)]
        public string? LastName { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        [MaxLength(500)]
        public string? ImagePath { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Balance { get; set; }
        public UserStatusEnum Status { get; set; } = UserStatusEnum.Pending;
        [MaxLength(255)]
        //navigation
        public int CityId { get; set; }
        public City? City { get; set; }
        public Admin? Admin { get; set; }
        public Specialist? Specialist { get; set; }
        public Customer? Customer { get; set; }

    }
}


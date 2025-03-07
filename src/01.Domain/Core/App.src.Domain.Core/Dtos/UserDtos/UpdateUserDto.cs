using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.src.Domain.Core.Dtos.UserEntities
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "تعداد کاراکت بیش از حد مجاز")]
        public string? FirstName { get; set; }
        [MaxLength(100, ErrorMessage = "تعداد کاراکت بیش از حد مجاز")]
        public string? LastName { get; set; }
        [MaxLength(500)]
        public string? ImagePath { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }
        [MaxLength(255, ErrorMessage = "تعداد کاراکت بیش از حد مجاز")]
        public int CityId { get; set; }
        public bool IsConfirmed { get; set; }
        public string? RoleName { get; set; }
        public string CityName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}


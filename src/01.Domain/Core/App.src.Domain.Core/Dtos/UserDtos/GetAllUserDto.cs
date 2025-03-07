using App.src.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Dtos.UserEntities
{
    public class GetAllUserDto
    {
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "تعداد کاراکتر استفاده شده بیش از حد مجاز")]
        public string? LastName { get; set; }
        public string? ImagePath { get; set; }
        public UserStatusEnum Status { get; set; } = UserStatusEnum.Pending;
        public string? RoleName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }



}


using App.src.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Dtos.UserEntities
{
    public class CreateUserDto
    {

        public string Password { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public int CityId { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}


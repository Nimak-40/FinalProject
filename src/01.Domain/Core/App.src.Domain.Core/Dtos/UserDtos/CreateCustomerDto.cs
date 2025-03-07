using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Dtos.UserEntities
{
    public class CreateCustomerDto
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }


    }
}


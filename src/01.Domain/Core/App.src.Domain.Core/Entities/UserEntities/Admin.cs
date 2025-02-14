using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.UserEntities
{
    public class Admin : User
    {
        [Required]
        public string AdminCode { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class Admin : User
    {
        [Required]
        public string AdminCode { get; set; }
    }
}


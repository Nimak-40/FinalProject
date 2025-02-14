using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.Orders
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    }
}


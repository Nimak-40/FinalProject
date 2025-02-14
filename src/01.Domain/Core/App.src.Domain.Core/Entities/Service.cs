using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public int ServiceCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(18, 2)]
        public double Price { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal BasePrice { get; set; }

        [Range(0, int.MaxValue)]
        public int EstimatedDurationInMinutes { get; set; }

        public virtual ServiceCategory ServiceCategory { get; set; }
    }
}


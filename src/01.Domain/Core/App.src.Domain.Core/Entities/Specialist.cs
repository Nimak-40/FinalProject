using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class Specialist : User
    {
        [Required]
        public string Specialty { get; set; }

        public string? Resume { get; set; }
        public string? Certificates { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public bool IsAvailable { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<OrderRequest> OrderRequests { get; set; } = new List<OrderRequest>();
    }
}


using Achare.src.Domain.Core.Entities;
using App.src.Domain.Core.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.UserEntities
{
    public class Specialist 
    {
        [Required]
        public string Specialty { get; set; }

        public string? Resume { get; set; }
        public string? Certificates { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public bool IsAvailable { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>(); 
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Offer> OffersRequests { get; set; } = new List<Offer>();
    }
}


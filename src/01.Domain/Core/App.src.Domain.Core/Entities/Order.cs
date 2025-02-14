using Achare.src.Domain.Core.Entities;
using Achare.src.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    [Required]
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime ScheduledDate { get; set; }

    [Required]
    public OrderStatus Status { get; set; }

    [Range(0, double.MaxValue)]
    public decimal TotalAmount { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<OrderRequest> OrderRequests { get; set; } = new List<OrderRequest>();
}

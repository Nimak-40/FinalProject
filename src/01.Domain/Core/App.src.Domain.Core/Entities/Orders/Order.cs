﻿using App.src.Domain.Core.Entities.BaseEntities;
using App.src.Domain.Core.Entities.Orders;
using App.src.Domain.Core.Entities.UserEntities;
using App.src.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public virtual CategoryService Service { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime ScheduledDate { get; set; }

        [Required]
        public OrderStatusEnum Status { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Offer>? OrderOffers { get; set; } = new List<Offer>();
    }
}

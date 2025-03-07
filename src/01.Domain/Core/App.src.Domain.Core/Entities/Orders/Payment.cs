using App.src.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.Orders
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Range(18, 2)]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public PaymentMethodEnum Method { get; set; }

        [Required]
        public PaymentStatusEnum Status { get; set; }
    }
}


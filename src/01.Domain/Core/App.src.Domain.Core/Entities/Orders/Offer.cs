using Achare.src.Domain.Core.Enums;
using App.src.Domain.Core.Entities.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.Orders
{
    public class Offer
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

        [Required]
        public int SpecialistId { get; set; }
        public virtual Specialist Specialist { get; set; }

        [Required]
        public string? Description { get; set; }

        public string? Suggestion { get; set; } 

        [Required]
        public decimal Price { get; set; } 

        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    }


}


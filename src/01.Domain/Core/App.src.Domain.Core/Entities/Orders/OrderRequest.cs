using Achare.src.Domain.Core.Enums;
using App.src.Domain.Core.Entities.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.Orders
{
    public class OrderRequest
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public int SpecialistId { get; set; }
        public virtual Specialist Specialist { get; set; }

        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    }

}


using Achare.src.Domain.Core.Enums;
using App.src.Domain.Core.Entities.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.Orders
{
    public class Offers
    {
        //description,suggestion,price
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public int SpecialistId { get; set; }
        public virtual Specialist Specialist { get; set; }

        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    }


}


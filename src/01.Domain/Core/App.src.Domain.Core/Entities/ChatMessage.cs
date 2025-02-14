using App.src.Domain.Core.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achare.src.Domain.Core.Entities
{

    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }

        [Required]
        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}


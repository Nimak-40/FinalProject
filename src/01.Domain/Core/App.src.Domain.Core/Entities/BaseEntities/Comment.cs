using App.src.Domain.Core.Entities.UserEntities;
using App.src.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Entities.BaseEntities
{

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }

        [Required]
        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; }

        [Required]
        public string? Message { get; set; }

        public CommentStatusEnum Status { get; set; } = CommentStatusEnum.Pending;
        public DateTime CreateAt { get; set; }
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}


using App.src.Domain.Core.Entities.Orders;
using App.src.Domain.Core.Entities.UserEntities;
using App.src.Domain.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.BaseEntities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int? CustomerId { get; set; }  // اصلاح نام

        public virtual Customer Customer { get; set; } // اصلاح نام

        [Required]
        public string Message { get; set; }  // حذف ? چون Required داریم

        public CommentStatusEnum Status { get; set; } = CommentStatusEnum.Pending;

        public DateTime CreateAt { get; set; } = DateTime.UtcNow; // مقدار پیش‌فرض اضافه شد

        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}

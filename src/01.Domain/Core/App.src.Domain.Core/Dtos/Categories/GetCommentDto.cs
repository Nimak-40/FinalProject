using App.src.Domain.Core.Enums;

namespace App.src.Domain.Core.Dtos.Categories
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public CommentStatusEnum Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime SentDate { get; set; }

        // مشخصات کاربر و سفارش
        public int CustomerId { get; set; }
        public int? OrderId { get; set; }
    }



}


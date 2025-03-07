using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Dtos.Categories
{
    public class CreateSubServiceDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; } = null!;

        public string? ImagePath { get; set; }
        [Required]
        public int BasePrice { get; set; }
        [Display(Name = "توضیحات")]
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = null!;
        public int SubCategoryId { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; } = null!;
    }



}


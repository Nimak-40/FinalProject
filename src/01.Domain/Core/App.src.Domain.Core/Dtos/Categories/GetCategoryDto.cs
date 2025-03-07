namespace App.src.Domain.Core.Dtos.Categories
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int SubServiceCount { get; set; }
        public string ImagePath { get; set; } = null!;
    }



}


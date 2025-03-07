namespace App.src.Domain.Core.Dtos.Categories
{
    public class GetCategorytServiceDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImagePath { get; set; }

        public int BasePrice { get; set; }
        public string Description { get; set; } = null!;
        public string SubCategoryTitle { get; set; } = null!;

    }



}


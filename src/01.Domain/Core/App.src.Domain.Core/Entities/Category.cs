using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class Category
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; } = null!;
        [MaxLength(500)]
        [Required]
        public string ImagePath { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        #endregion


        #region NavigationProperties
        public List<SubCategory> SubCategories { get; set; } = [];
        #endregion
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.src.Domain.Core.Entities
{
    public class SubCategory
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string Title { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        #endregion

        #region NavigationProperties
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<CategoryService> Services { get; set; } = new List<CategoryService>();
        #endregion
    }

}


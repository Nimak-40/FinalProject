using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class SubCategory
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        #endregion

        #region NavigationProperties
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Service> Services { get; set; } = [];
        #endregion
    }
}


using App.src.Domain.Core.Entities.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class Service
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; } = null!;
        [MaxLength(500)]
        public string? ImagePath { get; set; }
        [Required]
        public int Price { get; set; }
        [MaxLength(255)]
        [Required]
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        #endregion

        #region NavigationProperties
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Specialist> Specialists { get; set; } = new List<Specialist>();
        #endregion
    }

}


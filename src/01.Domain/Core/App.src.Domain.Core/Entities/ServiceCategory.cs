using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class ServiceCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Icon { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Service>? Services { get; set; } = new List<Service>();

    }
}


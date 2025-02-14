using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public int? CityId { get; set; }
        public virtual City? City { get; set; }

        public virtual ICollection<ChatMessage> SentMessages { get; set; } = new List<ChatMessage>();
        public virtual ICollection<ChatMessage> ReceivedMessages { get; set; } = new List<ChatMessage>();


    }
}


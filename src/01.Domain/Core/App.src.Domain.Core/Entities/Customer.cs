namespace Achare.src.Domain.Core.Entities
{
    public class Customer : User
    {
        public string? PreferredAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}


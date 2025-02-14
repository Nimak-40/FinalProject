﻿using System.ComponentModel.DataAnnotations;

namespace Achare.src.Domain.Core.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}


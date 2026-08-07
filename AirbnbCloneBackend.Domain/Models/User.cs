using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}

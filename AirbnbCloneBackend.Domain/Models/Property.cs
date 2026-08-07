using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Domain.Models
{
    public class Property
    {
        public int Id { get; set; }
        public required string PropertyName { get; set; }
        public required string Location { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string FileName { get; set; } = string.Empty;
        // Active / Inactive
        public bool Status { get; set; } = true;
        public required DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation Property
        public User User { get; set; } = null!;
        public Guid UserId { get; set; }

    }
}

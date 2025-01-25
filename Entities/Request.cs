﻿using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Request
    {
        [Key]
        public string Id { get; set; } = $"req_{Guid.NewGuid():N}";

        public required string Status { get; set; }

        [DataType(DataType.Text)]
        public required string Question { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Answer { get; set; }

        [DataType(DataType.Url)]
        public string? ModelGateway { get; set; }

        public string? ModelAi { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public required string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public required string SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public string ServiceId { get; set; }
        public Service Service { get; set; }

        public ICollection<EventRequest> Events { get; set; } = [];

    }
}
﻿using System.ComponentModel.DataAnnotations;

namespace Entities
{
    

    public class ModelAi
    {
        [Key]
        public string Id { get; set; } = $"mod_{Guid.NewGuid():N}";
        public required string Name { get; set; }
        public string? Token { get; set; }
        public string? AbsolutePath { get; set; }
        public string? Category { get; set; }
        public string? Language { get; set; }
        public  bool? IsStandard { get; set; }
        public string? Gender { get; set; }

        public string? Dialect { get; set; }
        public string? Type { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoogleNote.Core.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int UserId { get; set; }

        public int ColorId { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public ICollection<Label> Labels { get; set; }
    }
}

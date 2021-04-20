using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleNote.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Email { get; set; }
        
        #nullable enable
        public string? SocialId { get; set; }
        #nullable disable
        
        public string Password { get; set; }

        public string Name { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Label> Labels { get; set; }
    }
}

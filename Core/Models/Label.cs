using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoogleNote.Core.Models
{
    public class Label
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}

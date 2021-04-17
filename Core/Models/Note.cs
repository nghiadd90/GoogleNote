using System;

namespace GoogleNote.Core.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
        public long UserId { get; set; }
    }
}
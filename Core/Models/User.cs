using System;

namespace GoogleNote.Core.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string SocialId { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
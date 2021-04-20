using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoogleNote.Core.Models
{
    public class NoteLabel
    {
        public int NoteId { get; set; }
        
        public int LabelId { get; set; }
        
        public Note Note { get; set; }

        public Label Label { get; set; }
    }
}

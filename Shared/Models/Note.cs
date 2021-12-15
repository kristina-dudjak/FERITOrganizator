using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FERITOrganizator.Shared.Models
{
    [Table("Note", Schema ="dbo")]
    public partial class Note
    {
        public long NoteId { get; set; }
        public string Name { get; set; }
        public bool? IsDone { get; set; }
        public DateTime? Due { get; set; }
    }
}

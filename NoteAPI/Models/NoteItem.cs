using System.ComponentModel.DataAnnotations;

namespace NoteAPI.Models
{
    public class NoteItem
    {
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        // A note doesn't have to be contained in a folder.
        public int? FolderId { get; set; }
    }
}

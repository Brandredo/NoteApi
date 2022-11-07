using System.ComponentModel.DataAnnotations;

namespace NoteAPI.Models
{
    public class NoteUpdate
    {
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        // A note doesn't have to be contained in a folder.
        [Required]
        public int NewFolderId { get; set; }
        [Required]
        public int FolderId { get; set; }
    }
}

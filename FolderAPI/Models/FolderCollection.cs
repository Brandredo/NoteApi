using NoteAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FolderAPI.Models
{
    public class FolderCollection
    {
        [Required]
        public string Name { get; set; }

        public List<NoteItem> Notes { get; set; }

        public int Id { get; set; }

        private static int inc = 1;

        public FolderCollection()
        {
            Id = inc++;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using NoteAPI.Models;

namespace Note.API
{
    public interface INoteRepository
    {
        Task<List<NoteItem>> GetNotes();
        Task<NoteItem> GetNoteByTitle(string title);

        Task<NoteItem> AddNote(NoteItem note);

        Task<NoteItem> UpdateNote(NoteItem note);

        Task<int> DeleteNote(string title);

        Task<List<NoteItem>> GetFolderNotesAsync(int folderId);
    }
}

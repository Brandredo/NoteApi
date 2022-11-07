using FolderAPI.Models;
using NoteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal interface IRepository
    {
        Task<List<FolderCollection>> GetAllFoldersAsync();
        Task<FolderCollection> GetFolderAsync(int id);

        Task DeleteFolderAsync(int id);

        Task<FolderCollection> EditFolder(FolderCollection folder);

        Task<FolderCollection> CreateFolder(FolderCollection folder);

        Task<List<NoteItem>> AddNoteToFolderAsync(NoteItem note);

        Task<bool> CheckExistsAsync(int id);

        Task<bool> DeleteNoteFromFolderAsync(NoteUpdate note);

        Task<List<NoteItem>> GetNotesOfFolderAsync(int folderId);

        Task<List<NoteItem>> GetNotes();
        Task<NoteItem> GetNoteByTitle(string title);

        Task<NoteItem> AddNote(NoteItem note);

        Task<NoteItem> UpdateNote(NoteItem note);

        Task<int> DeleteNote(string title);

        Task<List<NoteItem>> GetFolderNotesAsync(int folderId);

    }
}

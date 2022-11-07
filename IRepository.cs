using System;

public interface IRepository
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
}

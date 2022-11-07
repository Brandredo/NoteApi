//using FolderAPI.Models;
//using NoteAPI.Models;

//namespace DataLayer
//{
//    public class DataRepository : IRepository
//    {

//        //private List<NoteItem> notes;
//        //private Dictionary<Int32, List<NoteItem>> folders;

//        //public DataRepository()
//        //{
//        //    notes = new List<NoteItem>();
//        //    folders = new Dictionary<int, List<NoteItem>>();
          
//        //}



//        //public Task<List<NoteItem>> GetNotes()
//        //{
//        //    return Task.FromResult(_items);
//        //}


//        //public Task<NoteItem> AddNote(NoteItem note)
//        //{
//        //    _items.Add(note);
//        //    return Task.FromResult(note);
//        //}

//        //public Task<int> DeleteNote(string title)
//        //{
//        //    return Task.FromResult(_items.RemoveAll(t => t.Title.ToLower() == title));
//        //}

//        //public Task<NoteItem> GetNoteByTitle(string title)
//        //{
//        //    return Task.FromResult(_items.FirstOrDefault(t => t.Title.ToLower() == title));
//        //}

//        //public Task<NoteItem> UpdateNote(NoteItem note)
//        //{
//        //    NoteItem n = _items.FirstOrDefault(t => t.Title.ToLower() == note.Title.ToLower());

//        //    if (n == null)
//        //    {
//        //        return Task.FromResult(new NoteItem());
//        //    }

//        //    n.Title = note.Title;
//        //    n.Text = note.Text;

//        //    if (note.FolderId != null) n.FolderId = note.FolderId;

//        //    return Task.FromResult(n);
//        //}

//        ////public Task<NoteItem> UpdateNoteFolder(NoteItemUpdate note)
//        ////{
//        ////    NoteItem n = _items.FirstOrDefault(t => t.Title.ToLower() == note.Title.ToLower());
//        ////    if(n == null)
//        ////    {
//        ////        return Task.FromResult(new NoteItem());
//        ////    }

//        ////    if (note.FolderId != null) n.FolderId = note.NewFolderId;
//        ////}

//        //public Task<List<NoteItem>> GetFolderNotesAsync(int folderId)
//        //{
//        //    return Task.FromResult(_items.FindAll(note => note.FolderId == folderId));
//        //}


//        //public Task<bool> DeleteNoteFromFolderAsync(NoteUpdate note)
//        //{
//        //    FolderCollection? fd = folders.Find(folder => folder.Id == note.FolderId);

//        //    if (fd == null)
//        //    {
//        //        return Task.FromResult(false);
//        //    }

//        //    if (fd.Notes.RemoveAll(n => n.FolderId == note.FolderId) == 0)
//        //    {
//        //        return Task.FromResult(false);
//        //    }

//        //    return Task.FromResult(true);
//        //}

//        //public Task<FolderCollection> CreateFolder(FolderCollection folder)
//        //{
//        //    folders.Add(folder);
//        //    folder.Notes = new List<NoteItem>();
//        //    return Task.FromResult(folder);
//        //}

//        //public Task<List<NoteItem>> GetNotesOfFolderAsync(int folderId)
//        //{
//        //    if (folders.Find(f => f.Id == folderId) == null)
//        //    {
//        //        return null;
//        //    }

//        //    return Task.FromResult(folders.Find(f => f.Id == folderId).Notes);

//        //}

//        //public Task DeleteFolderAsync(int id)
//        //{
//        //    folders.RemoveAll(folder => folder.Id == id);
//        //    return Task.FromResult("Folder Deleted.");
//        //}

//        //public Task<List<NoteItem>> AddNoteToFolderAsync(NoteItem note)
//        //{
//        //    FolderCollection? folder = folders.Find(folder => folder.Id == note.FolderId);

//        //    if (folder == null)
//        //    {
//        //        return Task.FromResult(new List<NoteItem>());
//        //    }

//        //    folder.Notes.Add(note);

//        //    return Task.FromResult(folder.Notes);

//        //}

//        //public Task<FolderCollection> EditFolder(FolderCollection folder)
//        //{

//        //    FolderCollection folderResult = folders.Find(f => f.Id == folder.Id && f.Name == folder.Name);
//        //    if (folderResult == null)
//        //    {
//        //        throw new NullReferenceException();// Fix this
//        //    }

//        //    return Task.FromResult(folderResult);
//        //}

//        //public Task<List<FolderCollection>> GetAllFoldersAsync()
//        //{
//        //    return Task.FromResult(folders);
//        //}

//        //public Task<FolderCollection> GetFolderAsync(int id)
//        //{
//        //    FolderCollection folder = folders.Find(f => f.Id == id);
//        //    return Task.FromResult(folder);
//        //}

//        //public Task<bool> CheckExistsAsync(int id)
//        //{
//        //    bool result = folders.Exists(f => f.Id == id);
//        //    return Task.FromResult(result);
//        //}

//    }
//}
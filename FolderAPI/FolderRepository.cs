
using FolderAPI.Models;
using NoteAPI.Models;

namespace Folder.API
{
    public class FolderRepository : IFolderRepository
    {

        private List<FolderCollection> folders;
        
        public FolderRepository()
        {
            folders = new List<FolderCollection>() {

                new FolderCollection() {
                    Name = "Reminders",
                    Notes = new List<NoteItem>()
                    {
                        new NoteItem() {
                            Title = "Title1",
                            Text = "Testing1",
                            FolderId = 1
                        }
                    }
                },
                new FolderCollection() {
                    Name = "Today",
                    Notes = new List<NoteItem>()
                    {
                        new NoteItem() {
                            Title = "Title3",
                            Text = "Testing3",
                            FolderId = 2
                        },
                        new NoteItem() {
                            Title = "Title2",
                            Text = "Testing2",
                            FolderId = 2
                        }
                    }
                },
                new FolderCollection(){
                    Name = "Old",
                    Notes= new List<NoteItem>()
                }
            
            
            };
        }

        public Task<bool> DeleteNoteFromFolderAsync(NoteUpdate note)
        {
            FolderCollection? fd = folders.Find(folder => folder.Id == note.FolderId);

            if(fd == null)
            {
                return Task.FromResult(false);
            }

            if(fd.Notes.RemoveAll(n => n.FolderId == note.FolderId) == 0)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<FolderCollection> CreateFolder(FolderCollection folder)
        {
            folders.Add(folder);
            folder.Notes = new List<NoteItem>();
            return Task.FromResult(folder);
        }

        public Task<List<NoteItem>> GetNotesOfFolderAsync(int folderId)
        {
            if(folders.Find(f => f.Id == folderId) == null)
            {
                return null;
            }

            return Task.FromResult(folders.Find(f => f.Id == folderId).Notes);
            
        }

        public Task DeleteFolderAsync(int id)
        {
            folders.RemoveAll(folder => folder.Id == id);
            return Task.FromResult("Folder Deleted.");
        }

        public Task<List<NoteItem>> AddNoteToFolderAsync(NoteItem note)
        {
            FolderCollection? folder = folders.Find(folder => folder.Id == note.FolderId);
            
            if(folder == null)
            {
                return Task.FromResult(new List<NoteItem>());
            }
            
            folder.Notes.Add(note);

            return Task.FromResult(folder.Notes);

        }

        public Task<FolderCollection> EditFolder(FolderCollection folder)
        {
            
            FolderCollection folderResult = folders.Find(f => f.Id == folder.Id && f.Name == folder.Name);
            if(folderResult == null)
            {
                throw new NullReferenceException();// Fix this
            }

            return Task.FromResult(folderResult);
        }

        public Task<List<FolderCollection>> GetAllFoldersAsync()
        {
            return Task.FromResult(folders);
        }

        public Task<FolderCollection> GetFolderAsync(int id)
        {
            FolderCollection folder = folders.Find(f => f.Id == id);
            return Task.FromResult(folder);
        }

        public Task<bool> CheckExistsAsync(int id)
        {
            bool result = folders.Exists(f => f.Id == id);
            return Task.FromResult(result);
        }
    }
}

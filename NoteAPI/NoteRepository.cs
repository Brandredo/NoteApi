using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NoteAPI.Models;

namespace Note.API
{
    public class NoteRepository : INoteRepository
    {
        private List<NoteItem> _items;
        private Dictionary<int, List<NoteItem>> folders;

        public NoteRepository()
        {
            _items = new List<NoteItem>() {

                new NoteItem()
                {
                    Title = "Grocery",
                    Text = "Eggs, Bread, Apples",
                    FolderId = 1
                },
                new NoteItem()
                {
                    Title = "Expenses",
                    Text = "Rent, Phone, Gym, Transit",
                    FolderId = 2
                },
                new NoteItem(){
                    Title = "Want to read this year",
                    Text = "Carnivale looks like a good book. Also checkout Mystery at Village Peek!",
                    FolderId = 1
                },
                new NoteItem(){
                    Title = "Technologies",
                    Text = "Docker and Angular"
                },
                new NoteItem(){
                    Title = "Reminders",
                    Text = "Take out the trash. Mow the lawn. Clean the dishes."
                }
            };

            folders = new Dictionary<int, List<NoteItem>>();
        }

        //public Task<List<NoteItem>> CreateFolder()
        //{
            
        //    if(folders.TryAdd(0, new List<NoteItem>()) == false)
        //    {
        //        // return bad request
        //    }
            


        //    folder.Notes = new List<NoteItem>();
        //    return Task.FromResult(folder);
        //}


        public Task<List<NoteItem>> GetNotes()
        {
            return Task.FromResult(_items);
        }


        public Task<NoteItem> AddNote(NoteItem note)
        {
            _items.Add(note);
            return Task.FromResult(note);
        }

        public Task<int> DeleteNote(string title)
        {
            return Task.FromResult(_items.RemoveAll(t => t.Title.ToLower() == title));
        }

        public Task<NoteItem> GetNoteByTitle(string title)
        {
            return Task.FromResult(_items.FirstOrDefault(t => t.Title.ToLower() == title));
        }

        public Task<NoteItem> UpdateNote(NoteItem note)
        {
            NoteItem n = _items.FirstOrDefault(t => t.Title.ToLower() == note.Title.ToLower());
            
            if(n == null)
            {
                return Task.FromResult(new NoteItem());
            }
            
            n.Title = note.Title;
            n.Text = note.Text;

            if (note.FolderId != null) n.FolderId = note.FolderId;

            return Task.FromResult(n);
        }

        //public Task<NoteItem> UpdateNoteFolder(NoteItemUpdate note)
        //{
        //    NoteItem n = _items.FirstOrDefault(t => t.Title.ToLower() == note.Title.ToLower());
        //    if(n == null)
        //    {
        //        return Task.FromResult(new NoteItem());
        //    }

        //    if (note.FolderId != null) n.FolderId = note.NewFolderId;
        //}

        public Task<List<NoteItem>> GetFolderNotesAsync(int folderId)
        {
            return Task.FromResult(_items.FindAll(note => note.FolderId == folderId));
        }

    }
}

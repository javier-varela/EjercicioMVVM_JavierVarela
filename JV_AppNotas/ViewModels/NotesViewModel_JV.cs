using CommunityToolkit.Mvvm.Input;
using JV_AppNotas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace JV_AppNotas.ViewModels
{
    internal class NotesViewModel_JV: IQueryAttributable
    {
        public NotesViewModel_JV()
        {
            AllNotes = new ObservableCollection<ViewModels.NoteViewModel_JV>(Models.NoteJV.LoadAll().Select(n => new NoteViewModel_JV(n)));
            NewCommand_JV = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand_JV = new AsyncRelayCommand<ViewModels.NoteViewModel_JV>(SelectNoteAsync);
        }
        public ObservableCollection<ViewModels.NoteViewModel_JV> AllNotes { get; }
        public ICommand NewCommand_JV { get; }
        public ICommand SelectNoteCommand_JV { get; }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.NotePage));
        }

        private async Task SelectNoteAsync(ViewModels.NoteViewModel_JV note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.NotePage)}?load={note.Identifier}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                NoteViewModel_JV matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                NoteViewModel_JV matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                    matchedNote.Reload();

                // If note isn't found, it's new; add it.
                else
                    AllNotes.Add(new NoteViewModel_JV(NoteJV.Load(noteId)));
            }
        }
    }
}

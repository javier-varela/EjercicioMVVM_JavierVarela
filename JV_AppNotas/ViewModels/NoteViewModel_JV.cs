using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JV_AppNotas.ViewModels
{
    internal class NoteViewModel_JV : ObservableObject, IQueryAttributable
    {
        private Models.NoteJV _note;
        public ICommand SaveCommand_JV { get; private set; }
        public ICommand DeleteCommand_JV { get; private set; }

        public NoteViewModel_JV()
        {
            _note = new Models.NoteJV();
            SaveCommand_JV = new AsyncRelayCommand(Save);
            DeleteCommand_JV = new AsyncRelayCommand(Delete);
        }

        public NoteViewModel_JV(Models.NoteJV note)
        {
            _note = note;
            SaveCommand_JV = new AsyncRelayCommand(Save);
            DeleteCommand_JV = new AsyncRelayCommand(Delete);
        }

        public string Text
        {
            get => _note.Text;
            set
            {
                if (_note.Text != value)
                {
                    _note.Text = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date => _note.Date;

        public string Identifier => _note.Filename;

        private async Task Save()
        {
            _note.Date = DateTime.Now;
            _note.Save();
            await Shell.Current.GoToAsync($"..?saved={_note.Filename}");
        }

        private async Task Delete()
        {
            _note.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_note.Filename}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _note = Models.NoteJV.Load(query["load"].ToString());
                RefreshProperties();
            }
        }

        public void Reload()
        {
            _note = Models.NoteJV.Load(_note.Filename);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(Date));
        }
    }
}

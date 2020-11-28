using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PoemaDay.model;
using Xamarin.Forms;

namespace PoemaDay.viewmodel
{
    public class SavedPoemVM : BindableObject
    {
        public Poem selectedPoem { get; set; }
        public Command<Poem> FavoriteCommand { get; set; }

        ObservableCollection<Poem> poems;

        public ObservableCollection<Poem> Poems
        {
            get { return poems; }
            set
            {
                poems = value;
                OnPropertyChanged();
            }
        }

        public SavedPoemVM()
        {
            LoadPoems();

            FavoriteCommand = new Command<Poem>((f) =>
            {
                MessagingCenter.Send(f, "Favorited");
            });
        }

        void LoadPoems()
        {
            var _poems = Poem.GetSavedPoems();
            Poems = new ObservableCollection<Poem>(_poems);
        }
    }
}

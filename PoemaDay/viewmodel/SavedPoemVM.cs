using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmCross.ViewModels;
using PoemaDay.model;
using Xamarin.Forms;

namespace PoemaDay.viewmodel
{
    public class SavedPoemVM : MvxViewModel
    {
        public Poem selectedPoem { get; set; }
        public Command<Poem> DeleteCommand { get; set; }
        public Command<Poem> NavigateCommand { get; set; }

        ObservableCollection<Poem> poems;

        public ObservableCollection<Poem> Poems
        {
            get { return poems; }
            set
            {
                poems = value;
                RaisePropertyChanged(() => Poems);
            }
        }

        public SavedPoemVM()
        {
            LoadPoems();

            DeleteCommand = new Command<Poem>((f) =>
            {
                Poem.DeletePoem(f);
                LoadPoems();
            });

            NavigateCommand = new Command<Poem>((f) =>
            {
                NavigateToDetailPage(f);
            });
        }

        public void LoadPoems()
        {
            //var _poems = Poem.GetSavedPoems();
            //Poems = new ObservableCollection<Poem>(_poems);
        }


        private async void NavigateToDetailPage(Poem poem)
        {
            PoemDetail poemDetail = new PoemDetail
            {
                BindingContext = poem
            };
            await FormsApp.Current.MainPage.Navigation.PushAsync(poemDetail);

        }
    }
}

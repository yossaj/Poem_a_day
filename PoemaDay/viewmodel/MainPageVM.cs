using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using PoemaDay.model;
using PoemaDay.viewmodel.commands;

namespace PoemaDay.viewmodel
{
    public class MainPageVM : MvxViewModel
    {

        private Poem _poem;
        public Poem poem
        {
            get => _poem;
            set
            {
                _poem = value;
                RaisePropertyChanged(() => poem);
            }
        }

        

        public NavigationCommands NavCommands { get; set; }
        public SavePoemCommand SaveCommand { get; set; }

        public  MainPageVM()
        {
            NavCommands = new NavigationCommands(this);
            SaveCommand = new SavePoemCommand(this);
            LoadPoem();
        }

        public void Navigate()
        {
             FormsApp.Current.MainPage.Navigation.PushAsync(new SavedPoems());
        }

        public void SaveCurrentPoem()
        {
            if (Poem.SavePoem(poem))
            {
                FormsApp.Current.MainPage.DisplayAlert("Success", "Poem saved", "OK");
            }
            else
            {
                FormsApp.Current.MainPage.DisplayAlert("Something Went Wrong", "Poem not saved", "OK");
            }
        }

        public async override Task Initialize()
        {
            await base.Initialize();
        }

        public async void LoadPoem()
        {
            poem = await Poem.GetPoem();
        }
    }
}

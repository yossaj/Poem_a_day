using System;
using PoemaDay.model;
using PoemaDay.viewmodel.commands;

namespace PoemaDay.viewmodel
{
    public class MainPageVM
    {

        public Poem poem { get; set; }

        public NavigationCommands NavCommands { get; set; }
        public SavePoemCommand SaveCommand { get; set; }

        public MainPageVM()
        {

            NavCommands = new NavigationCommands(this);
            SaveCommand = new SavePoemCommand(this);
        }

        public void Navigate()
        {
             App.Current.MainPage.Navigation.PushAsync(new SavedPoems());
        }

        public void SaveCurrentPoem()
        {
            if (Poem.SavePoem(poem))
            {
                App.Current.MainPage.DisplayAlert("Success", "Poem saved", "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Something Went Wrong", "Poem not saved", "OK");
            }
        }
    }
}

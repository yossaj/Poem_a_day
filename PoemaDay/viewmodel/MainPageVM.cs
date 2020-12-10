using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;
using PoemaDay.model;
using PoemaDay.viewmodel.commands;

namespace PoemaDay.viewmodel
{
    public class MainPageVM : MvxViewModel
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
    }
}

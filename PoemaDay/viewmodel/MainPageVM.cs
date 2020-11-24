using System;
using PoemaDay.model;
using PoemaDay.viewmodel.commands;

namespace PoemaDay.viewmodel
{
    public class MainPageVM
    {

        public Poem poem { get; set; }

        public NavigationCommands NavCommands { get; set; }

        public MainPageVM()
        {

            NavCommands = new NavigationCommands(this);
        }

        public void Navigate()
        {
             App.Current.MainPage.Navigation.PushAsync(new SavedPoems());
        }
    }
}

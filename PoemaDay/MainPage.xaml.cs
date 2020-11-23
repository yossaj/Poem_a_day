using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using PoemaDay.model;
using PoemaDay.services;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PoemaDay
{
    public partial class MainPage : ContentPage
    {
        Poem poem;

        public MainPage()
        {
            InitializeComponent();
            SetPoem();
            
        }

        private async void SetPoem() {
            poem = await Poem.GetPoem();
            mainContainerStack.BindingContext = poem;
        }

        void ArchiveButton_Clicked(System.Object sender, System.EventArgs e) => Navigation.PushAsync(new SavedPoems());

        void SaveButton_Clicked(System.Object sender, System.EventArgs e) => SavePoem();

        private void SavePoem()
        {
                if (Poem.SavePoem(poem))
                {
                    DisplayAlert("Success", "Poem saved: \n " + poem.concatLines.ToString() , "OK");
                }
                else
                {
                    DisplayAlert("Something Went Wrong", "Poem not saved", "OK");
                }
        }
    }

   
}

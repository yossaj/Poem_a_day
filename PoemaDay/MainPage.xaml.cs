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
        Poem poem = new Poem();

        public MainPage()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            poem = await PoemAPI.GetPoemAsync();
            SetPoem();
        }

        private void SetPoem() {

            PoemTitle.Text = poem.title;
            PoemAuthor.Text = poem.author;
            String lines = "";

            foreach (string pline in poem.lines)
            {
                lines += pline + "\n";
            }

            
            poem.concatLines = lines;
            PoemBody.Text = poem.concatLines;
        }

        void ArchiveButton_Clicked(System.Object sender, System.EventArgs e) => Navigation.PushAsync(new SavedPoems());

        void SaveButton_Clicked(System.Object sender, System.EventArgs e) => SavePoemToTable();

        private void SavePoemToTable()
        {
            using (SQLiteConnection conn = new   SQLiteConnection(App.DatabaseLocation))
            {
                var rows = 0;


                if (poem != null)
                {
                    conn.CreateTable<Poem>();
                    rows = conn.Insert(poem);
                }
                else
                {
                    DisplayAlert("Something Went Wrong", "Poem not saved", "OK");
                }
                
                if (rows > 0)
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

   
}

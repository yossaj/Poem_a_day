using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using PoemaDay.model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PoemaDay
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        Poem poem = new Poem();


        async void GetPoemAsync()
        {
            List<Poem> poems = new List<Poem>();
            using (HttpClient httpClient = new HttpClient())
            {
                Random rnd = new Random();
                int linecount = rnd.Next(2, 6);
                var response = await httpClient.GetAsync($"https://poetrydb.org/linecount/{linecount}");
                var json = await response.Content.ReadAsStringAsync();
                var poemList = JsonConvert.DeserializeObject<List<Poem>>(json);

                int leng = poemList.Count();
                
                int poemNum = rnd.Next(0, leng);

                
                PoemTitle.Text = poemList[poemNum].title;
                PoemAuthor.Text = poemList[poemNum].author;
                String lines = "";
                
                //var lines = new List<Line>();

                foreach (string pline in poemList[poemNum].lines)
                {
                    lines += pline + "\n";
                }
               
                PoemBody.Text = lines;
                poemList[poemNum].concatLines = lines;
                poem = poemList[poemNum];
            }

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetPoemAsync();
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
                    DisplayAlert("Something Went Wrong", "Experience was not added!", "OK");
                }
                
                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience add: " + rows.ToString(), "OK");
                }
                else
                {
                    DisplayAlert("Something Went Wrong", "Experience was not added!", "OK");
                }

            }
        }
    }

   
}

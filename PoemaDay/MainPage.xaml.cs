using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoemaDay.model;
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
                var lines = new List<Line>();
             
                foreach (string pline in poemList[poemNum].lines)
                {
                    Line newLine = new Line()
                    {
                        PoemLine = pline
                    };
                    lines.Add(newLine);
                }
                poemLineListView.ItemsSource = lines;


            }

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetPoemAsync();
        }
    }

   
}

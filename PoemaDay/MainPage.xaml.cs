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
               var response = await httpClient.GetAsync("https://poetrydb.org/linecount/6");
                var json = await response.Content.ReadAsStringAsync();
                var poemList = JsonConvert.DeserializeObject<List<Poem>>(json);
                var leng = poemList.Count();
                PoemTitle.Text = poemList[0].title;
                PoemAuthor.Text = poemList[0].author;
                var lines = new List<Line>();
                foreach(string pline in poemList[0].lines)
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

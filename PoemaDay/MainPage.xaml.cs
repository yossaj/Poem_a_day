using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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


        void GetPoemAsync()
        {
            var request = WebRequest.Create("https://poetrydb.org/linecount/6") as HttpWebRequest;
            request.Method = "GET";
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
            var info = httpResponse.StatusCode;

           
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetPoemAsync();
        }
    }

   
}
